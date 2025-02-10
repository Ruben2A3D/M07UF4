using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollectionManager : MonoBehaviour
{
    // Variables para almacenar los objetos recogidos
    private bool hasBattery = false;
    private bool hasMagnifyingGlass = false;
    private bool hasAllSeeingEye = false;

    // Nombres de las escenas de las salas
    public string lightRoomScene = "SalaDeLaLuz"; // Nombre de la escena de la Sala de la Luz
    public string darkRoomScene = "SalaOscura";   // Nombre de la escena de la Sala Oscura

    // Método para recoger objetos
    public void CollectObject(string objectName)
    {
        switch (objectName)
        {
            case "Battery":
                if (!hasBattery && !hasMagnifyingGlass && !hasAllSeeingEye)
                {
                    hasBattery = true;
                    Debug.Log("Pila recogida.");
                }
                else
                {
                    Debug.Log("¡Orden incorrecto! Debes recoger la pila primero.");
                }
                break;

            case "MagnifyingGlass":
                if (hasBattery && !hasMagnifyingGlass && !hasAllSeeingEye)
                {
                    hasMagnifyingGlass = true;
                    Debug.Log("Lupa recogida.");
                }
                else
                {
                    Debug.Log("¡Orden incorrecto! Debes recoger la lupa después de la pila.");
                }
                break;

            case "AllSeeingEye":
                if (hasBattery && hasMagnifyingGlass && !hasAllSeeingEye)
                {
                    hasAllSeeingEye = true;
                    Debug.Log("Ojo que todo lo ve recogido.");
                    CheckOrderAndTeleport();
                }
                else
                {
                    Debug.Log("¡Orden incorrecto! Debes recoger el ojo que todo lo ve al final.");
                }
                break;

            default:
                Debug.Log("Objeto no reconocido.");
                break;
        }
    }

    // Método para verificar el orden y teletransportar
    private void CheckOrderAndTeleport()
    {
        if (hasBattery && hasMagnifyingGlass && hasAllSeeingEye)
        {
            Debug.Log("¡Orden correcto! Teletransportando a la Sala de la Luz.");
            LoadScene(lightRoomScene);
        }
        else
        {
            Debug.Log("¡Orden incorrecto! Teletransportando a la Sala Oscura.");
            LoadScene(darkRoomScene);
        }
    }

    // Método para cargar una escena
    private void LoadScene(string sceneName)
    {
        // Cargar la escena correspondiente
        SceneManager.LoadScene(sceneName);
    }
}