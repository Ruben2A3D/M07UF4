using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraSwitchWithAnimation : MonoBehaviour
{
    public Camera mainCamera; // Referencia a la cámara principal
    public Camera secondaryCamera; // Referencia a la cámara secundaria
    public Animator secondaryCameraAnimator; // Referencia al Animator de la cámara secundaria
    public string animationName; // Nombre de la animación de la cámara secundaria
    public float animationDuration; // Duración de la animación

    void Start()
    {
        // Asegúrate de que la cámara principal esté activa y la secundaria desactivada al inicio
        if (mainCamera != null && secondaryCamera != null)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
        else
        {
            Debug.LogWarning("Asigna las cámaras en el Inspector.");
        }
    }

    // Método que se ejecuta cuando el personaje entra en el trigger
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
        // Cambiar a la cámara secundaria
        if (mainCamera != null && secondaryCamera != null)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
        }

        // Reproducir la animación de la cámara secundaria
        if (secondaryCameraAnimator != null && !string.IsNullOrEmpty(animationName))
        {
            secondaryCameraAnimator.Play(animationName);
        }
        else
        {
            Debug.LogWarning("Animator o nombre de animación no configurado.");
        }

        // Esperar a que la animación termine
        yield return new WaitForSeconds(animationDuration);

        // Cambiar de vuelta a la cámara principal
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