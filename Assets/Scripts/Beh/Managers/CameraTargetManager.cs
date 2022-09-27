using Cinemachine;
using UnityEngine;

namespace JernJam
{
  /*
   * Not in use
   */
  public class CameraTargetManager : MonoBehaviour
  {
    [SerializeField] private CinemachineTargetGroup _cmTargetGroup;
    [SerializeField] private float _defaultCameraWeight = 5f;
    
    public void OnLevelInit()
    {
      // Add camera target to all the quest objects
      foreach (var questAuth in GameObject.FindObjectsOfType<QuestItemAuthoring>())
      {
        var go = questAuth.gameObject;
        var targetActivator = go.AddComponent<CameraTargetActivator>();
        targetActivator.weight = _defaultCameraWeight;
        targetActivator.isActiveCameraTarget = false;  // do I really need this attribute?..
        targetActivator.cameraTargetManager = this;

      }
    }

    /*
     * Called from a component when activated. We can add multiple targets - may be good for experience.
     */
    public void ChangeTarget(GameObject targetGameObject)
    {
      CinemachineTargetGroup.Target trgt = new CinemachineTargetGroup.Target();
      trgt.target = targetGameObject.transform;
      _cmTargetGroup.m_Targets = new CinemachineTargetGroup.Target[] { trgt };
    }
    
  }
}