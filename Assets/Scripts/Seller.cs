using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Seller : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    private PlayerMover _playerMover;
    private bool _canBuy = true;
    private float time = 1f;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << 8); //Quita la capa 8
            _playerMover = other.GetComponent<PlayerMover>();
            _playerMover.canMove = false;
            UI.SetActive(true);
            _canBuy = false;
        }
    }
    
}
