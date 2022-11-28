using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BonkSound : MonoBehaviour
{
    public PlayerMove playerScript;
    public AudioClip bonkSound;
    public AudioSource bonkSource;

    void Start()
    {
        playerScript = GetComponent<PlayerMove>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (playerScript.pushPower >= 60)
        {
            bonkSource.PlayOneShot(bonkSound);
        }
    }

    IEnumerator playSound()
    {
        bonkSource.PlayOneShot(bonkSound);

        yield return new WaitForSeconds(0.3f);
    }
}
