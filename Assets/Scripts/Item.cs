using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public Sprite Sprite;
    public void OnCollected()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        Destroy(gameObject); 
    }

    
}
