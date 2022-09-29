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
    private Camera _mainCam;
    public bool _isBeingGrabbed;

    public bool GetIsBeingGrabbed()
    {
      return _isBeingGrabbed;
    }
    
    public void Start()
    {
      _mainCam = Camera.main;
    }
    
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
      _isBeingGrabbed = true;
    }

    private void OnMouseUp()
    {
      _isBeingGrabbed = false;
    }

    private void OnMouseDrag()
    {
      if (!_dragEnabled) return;
      Vector3 newPosition = GetMouseWorldPos() + _offset;
      newPosition.y = _fixedInWorldYCoord;

      transform.position = ClampPosition(newPosition);
    }

    // So that the item never fly away
    // private void Update()
    // {
    //   if (_dragEnabled) return;  // we clamp OnMouseDrag as well
    //   var clampedPosition = ClampPosition(transform.position);
    //   if (clampedPosition != transform.position)
    //   {
    //     transform.position = clampedPosition;
    //   }
    // }

    public static Vector3 ClampPosition(Vector3 position)
    {
      Vector3 clampedPosition = Vector3.zero;
      if (position.x >= QuestItemsManager.instance.itemXZBounds.x)
      {
        clampedPosition.x = QuestItemsManager.instance.itemXZBounds.x;
      }
      else if (position.x <= -QuestItemsManager.instance.itemXZBounds.x)
      {
        clampedPosition.x = -QuestItemsManager.instance.itemXZBounds.x;
      }
      else
      {
        clampedPosition.x = position.x;
      }
      
      
      if (position.z >= QuestItemsManager.instance.itemXZBounds.y)
      {
        clampedPosition.z = QuestItemsManager.instance.itemXZBounds.y;
      }
      else if (position.z <= -QuestItemsManager.instance.itemXZBounds.y)
      {
        clampedPosition.z = -QuestItemsManager.instance.itemXZBounds.y;
      }
      else
      {
        clampedPosition.z = position.z;
      }

      clampedPosition.y = position.y;

      return clampedPosition;

    }

    private Vector3 GetMouseWorldPos()
    {
      Vector3 mousePoint = Input.mousePosition;
      mousePoint.z = _zCoord;
      
      return _mainCam.ScreenToWorldPoint(mousePoint);
    }
    
  }
  
}