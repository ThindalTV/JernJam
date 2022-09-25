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
    [SerializeField] private float _rotationSpeed = 100f;

    private float cameraToGroundAngleTan;

    private void Start()
    {
      UpdateCachedCameraProps();
    }

    private void UpdateCachedCameraProps()
    {
      // Tan(Angle) to calculate rotation point
      Vector3 startPoint = transform.position;
      Vector3 fwd = transform.forward.normalized;
      float alphaTan = fwd.magnitude / (new Vector3(0, fwd.y, 0)).magnitude;
      double beta = Math.PI / 2 - Math.Atan((double)alphaTan);
      cameraToGroundAngleTan = (float)Math.Tan(beta);
    }

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

      transform.localPosition = pos;
      
      if (Input.GetKey("q") || Input.GetKey("e"))
      {
        // Rotation around

        Vector3 startPoint = transform.position;
        Vector3 fwd = transform.forward;
        Vector3 groundForwardProjection = (new Vector3(fwd.x, 0, fwd.z)) * startPoint.y / cameraToGroundAngleTan 
                                          + new Vector3(startPoint.x, 0, startPoint.z);

        //Debug.DrawLine(groundForwardProjection, groundForwardProjection + Vector3.up * 10, Color.magenta, 5f);
        
        if (Input.GetKey("q"))
        {
          transform.RotateAround(groundForwardProjection, Vector3.up, -1 * _rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("e"))
        {
          transform.RotateAround(groundForwardProjection, Vector3.up, _rotationSpeed * Time.deltaTime);
        }
      }
      
    }
  }
}