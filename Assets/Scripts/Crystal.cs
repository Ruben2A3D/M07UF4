using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICollectable 
{

    public void OnCollected()
        {
            GameManager.gameManager.CoinCollected();
            Destroy(gameObject);
        }   
  

    
}