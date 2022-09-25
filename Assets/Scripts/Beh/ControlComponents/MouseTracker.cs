using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace JernJam
{
  // Not in use
  public class MouseTracker : MonoBehaviour
  {
    private Camera _mainCam;
    
    public void Start()
    {
      _mainCam = Camera.main;
    }
      
    public void Update()
    {

      Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out RaycastHit raycastHit))
      {
        this.transform.position = raycastHit.point;
      }
      
      
    }

    
  }
}