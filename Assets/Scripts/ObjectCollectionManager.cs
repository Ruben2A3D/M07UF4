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

    // Posiciones de las salas
    public Transform lightRoomPosition; // Posición de la Sala de la Luz
    public Transform darkRoomPosition;  // Posición de la Sala Oscura

    // Referencia al jugador
    public Transform player; // Asigna el transform del jugador en el Inspector

    // Método para recoger objetos
    public void CollectObject(string objectName)
    {
        switch (objectName)
        {
            case "Battery":
                Debug.Log(objectName);
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
                hasMagnifyingGlass = true;
                if (hasBattery && !hasMagnifyingGlass && !hasAllSeeingEye)
                {
                    Debug.Log("Lupa recogida.");
                }
                else
                {
                    Debug.Log("¡Orden incorrecto! Debes recoger la lupa después de la pila.");
                }
                break;

            case "AllSeeingEye":
                Debug.Log(objectName);
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
            Teleport(lightRoomPosition);
            SceneManager.LoadScene("SalaDeLaLuz");
        }
        else
        {
            Debug.Log("¡Orden incorrecto! Teletransportando a la Sala Oscura.");
            Teleport(darkRoomPosition);
            SceneManager.LoadScene("SalaOscura");
        }
    }

    // Método para teletransportar al jugador
    private void Teleport(Transform targetPosition)
    {
        if (player != null && targetPosition != null)
        {
            // Mueve al jugador a la posición de la sala correspondiente
            player.position = targetPosition.position;
            Debug.Log("Jugador teletransportado a: " + targetPosition.name);
        }
        else
        {
            Debug.LogError("Falta asignar el jugador o la posición de la sala.");
        }
    }
}