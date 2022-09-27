using System;
using UnityEngine;

namespace JernJam
{
  /* Attach to the quest boxes and the garbage bin */
  public class TargetBoxAuthoring : MonoBehaviour
  {
    [SerializeField] public QuestCategoryEnum questCategory;
    [SerializeField] public GameObject spitOutDirection;
    [SerializeField] public float spitOutForce = 7f;

    // private void OnDrawGizmos()
    // {
    //   Gizmos.color = Color.magenta;
    //   Gizmos.DrawLine(spitOutDirection.transform.position, spitOutDirection.transform.rotation*Vector3.up*spitOutForce);
    // }
  }
}