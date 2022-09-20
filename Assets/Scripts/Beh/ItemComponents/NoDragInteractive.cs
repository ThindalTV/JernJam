using System;
using UnityEngine;

namespace JernJam
{
  
  /*
   * Objects that should not be dragged. Still, they should act as camera targets and be activated with a click.
   */
  public class NoDragInteractive : MonoBehaviour
  {

    // Invoked when an object is clicked on
    public event EventHandler Interacted;
    
    private void OnMouseDown()
    {
      
    }
  }
}