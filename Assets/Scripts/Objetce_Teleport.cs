using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objecte_Teleport : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que se activará al entrar en el trigger
    public string sceneName = "GameOver"; // Nombre de la escena a cargar
    public float delayBeforeTeleport = 2f; // Retraso antes del teletransporte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("¡El objeto ha sido activado!");
            }
            else
            {
                Debug.LogError("No se ha asignado un objeto para activar.");
            }

            // Inicia la corrutina para el teletransporte con retraso
            StartCoroutine(TeleportAfterDelay());
        }
    }

    private IEnumerator TeleportAfterDelay()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delayBeforeTeleport);

        // Carga la escena GameOver
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Teletransportando a la escena: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("No se ha asignado un nombre de escena.");
        }
    }
}
