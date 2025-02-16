using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchAndAnimation : MonoBehaviour
{
    public Camera mainCamera; // Referencia a la c�mara principal
    public Camera secondaryCamera; // Referencia a la c�mara secundaria
    public Animator characterAnimator; // Referencia al Animator del personaje
    public string triggerParameter = "PlayFinalAnimation"; // Nombre del trigger en el Animator
    public int finalLayerIndex = 2; // �ndice de la capa "Final" (ajusta seg�n tu configuraci�n)

    void Start()
    {
        // Aseg�rate de que la c�mara principal est� activa y la secundaria desactivada al inicio
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;

        // Activar la capa "Final" en el Animator
        if (characterAnimator != null)
        {
            characterAnimator.SetLayerWeight(finalLayerIndex, 1); // Poner el peso de la capa "Final" a 1
        }
    }

    // M�todo que se ejecuta cuando el personaje entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el personaje (puedes usar tags)
        if (other.CompareTag("Player"))
        {
            SwitchCameraAndPlayAnimation();
        }
    }

    void SwitchCameraAndPlayAnimation()
    {
        // Desactivar la c�mara principal
        mainCamera.enabled = false;

        // Activar la c�mara secundaria
        secondaryCamera.enabled = true;

        // Activar el trigger en el Animator para reproducir la animaci�n en la capa "Final"
        if (characterAnimator != null && !string.IsNullOrEmpty(triggerParameter))
        {
            characterAnimator.SetTrigger(triggerParameter); // Activar el trigger
        }
        else
        {
            Debug.LogWarning("Animator o nombre del trigger no configurado.");
        }
    }
}