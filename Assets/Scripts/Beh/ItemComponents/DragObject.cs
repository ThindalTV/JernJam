using System;
using UnityEngine;

namespace JernJam
{
  
  /*
   * Makes the object draggable with a mouse
   */
  public class DragObject : MonoBehaviour
  {
    private Vector3 _offset;
    private float _zCoord;
    private float _fixedInWorldYCoord;
    private bool _dragEnabled = true;

    // Gameplay turn off / turn on if needed
    public void SetDragEnabled(bool isEnabled = true)
    {
      _dragEnabled = isEnabled;
    }

    // Y-offset to make the object fly right above the walls 
    public void SetWallYOffset(float yOffset)
    {
      _fixedInWorldYCoord = yOffset;
    }
    
    private void OnMouseDown()
    {
      if (!_dragEnabled) return;
      _zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
      _offset = gameObject.transform.position - GetMouseWorldPos();
    }
    
    private void OnMouseDrag()
    {
      if (!_dragEnabled) return;
      Vector3 newPosition = GetMouseWorldPos() + _offset;
      newPosition.y = _fixedInWorldYCoord;
      transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPos()
    {
      Vector3 mousePoint = Input.mousePosition;
      mousePoint.z = _zCoord;

      return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
  }
  
}