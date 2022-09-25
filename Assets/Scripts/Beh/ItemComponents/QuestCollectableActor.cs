using System;
using UnityEngine;

namespace JernJam
{
  /*
   * Item that counts as a collectable - describe quest tags here.
   */
  public class QuestCollectableActor : MonoBehaviour
  {
    public string itemDescription;
    
    private void OnMouseDown()
    {
      QuestDescriptionDisplay.instance.UpdateQuestText(itemDescription);
    }
    
  }
}