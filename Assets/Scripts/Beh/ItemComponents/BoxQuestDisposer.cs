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
    
    private void OnTriggerEnter(Collider other)
    {
      var attch = other.transform.GetComponent<QuestCollectableActor>();
      if (attch != null)
      {
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
            QuestDescriptionDisplay.instance.UpdateQuestText(
              QuestScoring.instance.wrongActionHint
            );
          }
          
          var go = other.transform.gameObject;
          go.SetActive(false);
          
        }
      }
    }
  
  }
  
}
