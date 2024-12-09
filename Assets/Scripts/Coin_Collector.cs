using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collector : MonoBehaviour

{

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll))
        icoll.OnCollected();
    }
   public interface ICollectables
  {
    public void Collect();
  }
}
