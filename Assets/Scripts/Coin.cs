using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable 
{
    public void OnCollected()
    {
        GameManager.gameManager.CoinCollected(1);
        Destroy(gameObject);
    }
}
