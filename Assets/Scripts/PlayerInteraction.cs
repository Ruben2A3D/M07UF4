using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Referencia al ObjectCollectionManager
    private ObjectCollectionManager collectionManager;

    private void Start()
    {
        // Busca el ObjectCollectionManager en la escena
        collectionManager = FindObjectOfType<ObjectCollectionManager>();
        if (collectionManager == null)
        {
            Debug.LogError("No se encontró el ObjectCollectionManager en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*var playerMover = GetComponent<PlayerMover>();
        playerMover.canMove = false;
        playerMover._moveDirection = Vector3.zero;*/

        // Verifica si el objeto tiene un tag específico
        switch (other.tag)
        {
            case "Battery":
                collectionManager.CollectObject("Battery");
                Destroy(other.gameObject); // Destruye el objeto recogido
                break;

            case "MagnifyingGlass":
                collectionManager.CollectObject("MagnifyingGlass");
                Destroy(other.gameObject); // Destruye el objeto recogido
                break;

            case "AllSeeingEye":
                collectionManager.CollectObject("AllSeeingEye");
                Destroy(other.gameObject); // Destruye el objeto recogido
                break;
        }
    }
}
