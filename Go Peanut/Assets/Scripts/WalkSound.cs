using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{

    public AudioClip walkSound;
    public AudioSource walkSoundSource;

    PlayerMove playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Audio();
    }

    public void Audio()
    {
        if (!walkSoundSource.isPlaying && playerScript.isWalking && !playerScript.didItPlay)
        {
            walkSoundSource.Play();
            playerScript.didItPlay = true;
        }

        if (!playerScript.isWalking)
        {
            walkSoundSource.Stop();
            playerScript.didItPlay = false;
        }

        Vector3 down = transform.TransformDirection(Vector3.down);
    }
}
