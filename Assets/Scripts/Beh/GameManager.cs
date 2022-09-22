using System;
using UnityEngine;

namespace JernJam
{
  /*
   * Manage other managers so that they behave in a predictable order (when some managers depend on other managers
   * it's hard to tune them with Awakes only).
   */
  [RequireComponent(typeof(QuestItemsManager))]
  public class GameManager : MonoBehaviour
  {
    private QuestItemsManager _questItemsManager;
    
    private void Start()
    {
      InitLevel();
    }
    
    private void InitLevel()
    {
      _questItemsManager = GetComponent<QuestItemsManager>();
      _questItemsManager.OnLevelInit();
    }
    
    
  }
}