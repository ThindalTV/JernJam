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
  }
}