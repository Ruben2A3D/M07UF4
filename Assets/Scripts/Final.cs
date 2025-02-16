using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraSwitchWithAnimation : MonoBehaviour
{
    public Camera mainCamera; // Referencia a la c�mara principal
    public Camera secondaryCamera; // Referencia a la c�mara secundaria
    public Animator secondaryCameraAnimator; // Referencia al Animator de la c�mara secundaria
    public string animationName; // Nombre de la animaci�n de la c�mara secundaria
    public float animationDuration; // Duraci�n de la animaci�n

    void Start()
    {
        // Aseg�rate de que la c�mara principal est� activa y la secundaria desactivada al inicio
        if (mainCamera != null && secondaryCamera != null)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
        else
        {
            Debug.LogWarning("Asigna las c�maras en el Inspector.");
        }
    }

    // M�todo que se ejecuta cuando el personaje entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el personaje (puedes usar tags)
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SwitchCamerasWithAnimation());
            DisablePlayerMovement(other);
        }
    }

    IEnumerator SwitchCamerasWithAnimation()
    {
        // Cambiar a la c�mara secundaria
        if (mainCamera != null && secondaryCamera != null)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
        }

        // Reproducir la animaci�n de la c�mara secundaria
        if (secondaryCameraAnimator != null && !string.IsNullOrEmpty(animationName))
        {
            secondaryCameraAnimator.Play(animationName);
        }
        else
        {
            Debug.LogWarning("Animator o nombre de animaci�n no configurado.");
        }

        // Esperar a que la animaci�n termine
        yield return new WaitForSeconds(animationDuration);

        // Cambiar de vuelta a la c�mara principal
        if (mainCamera != null && secondaryCamera != null)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
    }

    void DisablePlayerMovement(Collider player)
    {
        // Obtener el componente CharacterController del personaje
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // Desactivar el CharacterController
        }
        else
        {
            Debug.LogWarning("El personaje no tiene un CharacterController.");
        }
    }
}