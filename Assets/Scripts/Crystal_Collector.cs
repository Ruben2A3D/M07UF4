using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Crystal_Collector : MonoBehaviour
{
  private Animator _animator;

    private void Awake()
    {
       _animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable icoll))
        {
          icoll.OnCollected();
          if(icoll is Crystal)
          {
            _animator.SetTrigger("Collected");
            _animator.SetLayerWeight(1, 1);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            GetComponent<PlayerMover>().canMove = false;
            GetComponent<PlayerMover>()._moveDirection = Vector3.zero;
          }
        }
        
    }
   public interface ICollectables
  {
    public void Collect();
  }
}