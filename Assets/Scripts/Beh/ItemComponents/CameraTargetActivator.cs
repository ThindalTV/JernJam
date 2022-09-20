using UnityEngine;

namespace JernJam
{
  /*
   * Adds / removes the object to the camera targets group
   */
  public class CameraTargetActivator : MonoBehaviour
  {
    public CameraTargetManager cameraTargetManager;
    public bool isActiveCameraTarget;
    public float weight;
  }
}