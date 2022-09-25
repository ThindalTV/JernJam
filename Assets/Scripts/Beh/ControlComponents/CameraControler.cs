using System;
using UnityEngine;

namespace JernJam
{
  
  public class CameraControler : MonoBehaviour
  {
    [SerializeField] private float _panSpeed = 20f;
    [SerializeField] private float _panBorderWidth;
    [SerializeField] private Vector2 _panLimit = new Vector2(100, 100);
    [SerializeField] private float _scrollSpeed = 200f;
    [SerializeField] private float minY = 20f;
    [SerializeField] private float maxY = 100f;
    
    private void LateUpdate()
    {
      // Pan and zoom
      
      Vector3 pos = transform.position;
      Vector3 xzDir = Vector3.zero;

      if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _panBorderWidth)
      {
        xzDir.z += _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderWidth)
      {
        xzDir.z -= _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("a") || Input.mousePosition.x <= _panBorderWidth)
      {
        xzDir.x -= _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderWidth)
      {
        xzDir.x += _panSpeed * Time.deltaTime;
      }

      Vector3 cameraRot = transform.rotation.eulerAngles;
      Quaternion xzCamera = Quaternion.Euler(0, cameraRot.y, 0);
      xzDir = xzCamera * xzDir;
      
      float scroll = Input.GetAxis("Mouse ScrollWheel");
      Vector3 zoomDir = transform.forward * (scroll * _scrollSpeed * Time.deltaTime);
      
      pos += xzDir + zoomDir;
      pos.x = Mathf.Clamp(pos.x, -_panLimit.x, _panLimit.x);
      pos.y = Mathf.Clamp(pos.y, minY, maxY);
      pos.z = Mathf.Clamp(pos.z, -_panLimit.y, _panLimit.y);

      // Rotation around
      
      
      
      transform.localPosition = pos;
    }
  }
}