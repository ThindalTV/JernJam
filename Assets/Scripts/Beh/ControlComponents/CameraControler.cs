using System;
using UnityEngine;

namespace JernJam
{
  
  public class CameraControler : MonoBehaviour
  {
    [SerializeField] private float _panSpeed = 20f;
    [SerializeField] private float _panBorderWidth;
    [SerializeField] private Vector2 _panLimit = new Vector2(100, 100);

    private void Update()
    {
      Vector3 pos = transform.position;
      if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - _panBorderWidth)
      {
        pos.z += _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("s") || Input.mousePosition.y <= _panBorderWidth)
      {
        pos.z -= _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("a") || Input.mousePosition.x <= _panBorderWidth)
      {
        pos.x -= _panSpeed * Time.deltaTime;
      }
      if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - _panBorderWidth)
      {
        pos.x += _panSpeed * Time.deltaTime;
      }

      pos.x = Mathf.Clamp(pos.x, -_panLimit.x, _panLimit.x);
      pos.z = Mathf.Clamp(pos.z, -_panLimit.y, _panLimit.y);

      transform.localPosition = pos;
    }
  }
}