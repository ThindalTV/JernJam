using UnityEditor;
using UnityEngine;

namespace JernJam
{
  /*
   * Attach this monobehaviour to any game object that should be collectable into a box.
   * It injects everything we need for an item to be interactive and score the game.
   * Any settings to tune? Add them here.
   */
  public class QuestItemAuthoring : MonoBehaviour
  {
    [SerializeField] public string itemDescription;
    [SerializeField] public QuestCategoryEnum questCategory;
    
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
      string txt = "No category";
      if (questCategory == QuestCategoryEnum.Garbage)
      {
        txt = "Garbage";
      }
      else if (questCategory == QuestCategoryEnum.Furniture)
      {
        txt = "Furniture";
      }
      else if (questCategory == QuestCategoryEnum.PirateQuest)
      {
        txt = "Pirate";
      }
      else if (questCategory == QuestCategoryEnum.RacingQuest)
      {
        txt = "Racing";
      }
      else if (questCategory == QuestCategoryEnum.MrRobotQuest)
      {
        txt = "MrRobot";
      }
      Handles.Label(transform.position, txt);
    }
#endif

  }
}