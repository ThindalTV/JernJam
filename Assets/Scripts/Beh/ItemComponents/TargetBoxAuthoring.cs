using System;
using UnityEngine;

namespace JernJam
{
  /* Attach to the quest boxes and the garbage bin */
  public class TargetBoxAuthoring : MonoBehaviour
  {
    [SerializeField] public QuestCategoryEnum questCategory;
    [SerializeField] public Vector3 flyForceDirection = Vector3.up;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
      Gizmos.color = Color.magenta;
      Gizmos.DrawLine(transform.position, transform.position+flyForceDirection);
    }
#endif
    
  }
}