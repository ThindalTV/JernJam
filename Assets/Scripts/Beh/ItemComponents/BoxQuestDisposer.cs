using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JernJam
{
  
  /*
  * Attach to the box we need to collect items into / to the garbage bin.
  */
  public class BoxQuestDisposer : MonoBehaviour
  {
    public QuestCategoryEnum questCategory;
    private Animator _animator;
    public Vector3 flyForceDirection = Vector3.up * 20f;

    private void Awake()
    {
      _animator = GetComponent<Animator>();
    }
    
    /* Play animation that this box is ready to eat the quest item */
    private void OnTriggerEnter(Collider other)
    {
      var attch = other.transform.GetComponent<QuestCollectableActor>();
      if (attch == null) return;
      
      _animator.SetBool("ContainerIsActive", true);
    }

    /* Check if object is no more grabbed. If not grabbed and wrong category - spit it out.
     If not grabbed and correct category - take it in. */ 
    private void OnTriggerStay(Collider other)
    {
      var drg = other.transform.GetComponent<DragObject>();
      if (drg == null) return;
      if (!drg.GetIsBeingGrabbed())
      {
        
        var go = other.transform.gameObject;
        
        var attch = other.transform.GetComponent<QuestCollectableActor>();
        if (attch == null) return;
        if (attch.questCategory == questCategory || questCategory == QuestCategoryEnum.Garbage)
        {
          if (attch.questCategory != QuestCategoryEnum.Garbage && questCategory != QuestCategoryEnum.Garbage)
          {
            QuestScoring.instance.ScoreItem(
              QuestScoring.instance.relevantQuestScore
            );
            QuestDescriptionDisplay.instance.UpdateQuestText(
              QuestScoring.instance.correctActionHint
            );
          }
          else
          {
            QuestScoring.instance.ScoreItem(
              QuestScoring.instance.garbageScore
            );
            if (questCategory == QuestCategoryEnum.Garbage)
            {
              QuestDescriptionDisplay.instance.UpdateQuestText(
                QuestScoring.instance.wastedWorld
              );
            }
          }
          
          go.SetActive(false);
          _animator.SetBool("ContainerIsActive", false);
          
        }
        else
        {
          SpitOut(go);
          _animator.SetBool("ContainerIsActive", false);
        }
        
      }
    }
    
    private void OnTriggerExit(Collider other)
    {
      _animator.SetBool("ContainerIsActive", false);
    }

    /* If the object does not belong in a bax, throw it away somewhere */
    private void SpitOut(GameObject questGo)
    {
      var rb = questGo.GetComponent<Rigidbody>();
      if (rb == null) return;
      
      //rb.AddForce(Quaternion.Euler(-45,45,45) * Vector3.up * 20f);
      rb.AddForce(flyForceDirection);
    }
    
  }
}
