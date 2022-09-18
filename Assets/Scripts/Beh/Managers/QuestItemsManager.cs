using UnityEngine;

namespace JernJam
{
  /*
   * Responsible for all the quest objects (objects that we should find)
   */
  public class QuestItemsManager : MonoBehaviour
  {
    [SerializeField] private float _DragWallYLevel;
    
    public void OnLevelInit()
    {
      foreach (var questAuth in GameObject.FindObjectsOfType<QuestItemAuthoring>())
      {
        var go = questAuth.gameObject;
        var dragObject = go.AddComponent<DragObject>();
        dragObject.SetDragEnabled(true);
        dragObject.SetWallYOffset(_DragWallYLevel);
        
      }
    }
  }
}