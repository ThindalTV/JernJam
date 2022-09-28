using System;
using UnityEngine;

namespace JernJam
{
  /*
   * Responsible for all the quest objects (objects that we should find)
   */
  public class QuestItemsManager : MonoBehaviour
  {
    [SerializeField] private float _DragWallYLevel;
    [SerializeField] public Vector2 itemXZBounds = new Vector2(20, 20);
    
    public static QuestItemsManager instance { get; private set;  }
    
    
    private void Awake()
    {
      instance = this;

    }

    public void OnLevelInit()
    {
      // The items
      int maxScore = 0;
      int allItems = 0;
      foreach (var questAuth in GameObject.FindObjectsOfType<QuestItemAuthoring>())
      {
        var go = questAuth.gameObject;
        var dragObject = go.AddComponent<DragObject>();
        dragObject.SetDragEnabled(true);
        dragObject.SetWallYOffset(_DragWallYLevel);

        var questItem = go.AddComponent<QuestCollectableActor>();
        questItem.itemDescription = questAuth.itemDescription;
        questItem.questCategory = questAuth.questCategory;

        if (questItem.questCategory == QuestCategoryEnum.Garbage)
        {
          maxScore += QuestScoring.instance.garbageScore;
        }
        else
        {
          maxScore += QuestScoring.instance.relevantQuestScore;
        }

        allItems += 1;
        
        var rigidBody = go.AddComponent<Rigidbody>();
        
      }
      
      // The boxes for items
      foreach (var boxAuth in GameObject.FindObjectsOfType<TargetBoxAuthoring>())
      {
        var go = boxAuth.gameObject;
        var questBox = go.AddComponent<BoxQuestDisposer>();
        questBox.questCategory = boxAuth.questCategory;
      }

      QuestScoring.instance.maxScore = maxScore;
      QuestScoring.instance.allItemsCount = allItems;
      QuestScoring.instance.updateScoreUI();

    }
  }
}