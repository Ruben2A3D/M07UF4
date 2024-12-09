using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
  public Transform Destino;

  public void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Player"))
    {
        other.GetComponent<CharacterController>().enabled = false;
        other.transform.position = Destino.position;
        other.GetComponent<CharacterController>().enabled = true;
    }
  }

}
