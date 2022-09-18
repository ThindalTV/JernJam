using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JernJam
{
  
  /*
  * Attach to the box we need to collect items into / to the garbage bin.
  */
  public class ItemDisposer : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      var attch = other.transform.GetComponent<QuestCollectableActor>();
      if (attch != null)
      {
        //GameController.instance.someBlockDestroyed.Invoke();
        //attch.blockDisposed.Invoke();
        //Transform viewBlock = attch.blockView;
        Destroy(other.transform.gameObject);
        //Destroy(viewBlock.transform.gameObject);
      }
    }
  
  }
  
}
