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
    public Vector3 spitOutDirection;
    public float spitOutForce;
    
    private Animator _animator;

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
      
      // var go = other.transform.gameObject;
      // if (attch.questCategory == questCategory || questCategory == QuestCategoryEnum.Garbage)
      // {
      //   if (attch.questCategory != QuestCategoryEnum.Garbage && questCategory != QuestCategoryEnum.Garbage)
      //   {
      //     QuestScoring.instance.ScoreItem(
      //       QuestScoring.instance.relevantQuestScore
      //     );
      //     QuestDescriptionDisplay.instance.UpdateQuestText(
      //       QuestScoring.instance.correctActionHint
      //     );
      //   }
      //   else
      //   {
      //     QuestScoring.instance.ScoreItem(
      //       QuestScoring.instance.garbageScore
      //     );
      //   }
      //   
      //   go.SetActive(false);
      //   
      // }
      // else
      // {
      //   SpitOut(go);
      // }
      
      
    }

    /* */ 
    private void OnTriggerStay(Collider other)
    {
      var drg = other.transform.GetComponent<DragObject>();
      if (drg == null) return;
      if (!drg.GetIsBeingGrabbed())
      {
        SpitOut(drg.gameObject);
      }
    }
    
    private void OnTriggerExit(Collider other)
    {
      _animator.SetBool("ContainerIsActive", false);
    }

    /* If the object does not belong in a bax, throw it away somewhere */
    private void SpitOut(GameObject questGo)
    {
      //Debug.Log("SPITTING OUT!!");
      var rb = questGo.GetComponent<Rigidbody>();
      if (rb == null) return;
      
      rb.AddForce(Quaternion.Euler(45,0,45) * Vector3.up * 10f);
      //rb.AddForce(spitOutDirection * spitOutForce);
      //Debug.DrawLine(questGo.transform.position, spitOutDirection * spitOutForce, Color.magenta, 3f);
    }
    
  }
}
