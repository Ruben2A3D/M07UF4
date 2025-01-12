using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    public int ID;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Coin" + ID) && PlayerPrefs.GetInt("Coin" + ID) == 1)
            LoadCoin();
    }

    private void OnTriggerEnter(Collider Other)
    {
        PlayerPrefs.SetInt("Coin" + ID, 1);
    }

    public void LoadCoin()
    {
        GameManager.gameManager.CoinCollected(1);
        gameObject.SetActive(false);
    }
}
