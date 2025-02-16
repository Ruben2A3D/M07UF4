using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour

{
    public GameObject objecte; // Asigna el objeto que aparecerá en el Inspector
    public GameObject[] objectsToActivate;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Activa el objeto para que aparezca
            if (objecte != null)
            {
                objecte.SetActive(true);
                Debug.Log("¡El objeto ha aparecido!");
            }
            else
            {
                Debug.LogError("No se ha asignado un objeto para aparecer.");
            }

            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                    Debug.Log("Objeto activado: " + obj.name);
                }
            }
        }
    }
}
