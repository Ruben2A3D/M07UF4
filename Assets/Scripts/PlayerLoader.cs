using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("playerPosX"))
            Load();
    }

    public void Load()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"),
            PlayerPrefs.GetFloat("playerPosY"), PlayerPrefs.GetFloat("playerPosZ"));
        transform.rotation = Quaternion.Euler(new Vector3(PlayerPrefs.GetFloat("playerRotX"),
            PlayerPrefs.GetFloat("playerRoty"), PlayerPrefs.GetFloat("playerRotZ")));
        StartCoroutine(WaitNextFrame());
    }

    private IEnumerator WaitNextFrame()
    {
        yield return new WaitForEndOfFrame();
        GetComponent<CharacterController>().enabled = true;
    }
}
