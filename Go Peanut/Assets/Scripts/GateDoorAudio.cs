using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoorAudio : MonoBehaviour
{

    public AudioSource audiosource;
    public AudioClip dooropen;
    public AudioClip doorclose;

    public Animator doorAnim;
    public Animator doorAnim2;

    public GameObject door1;
    public GameObject door2;

    public bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        doorAnim = door1.GetComponent<Animator>();
        doorAnim2 = door2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName("OpenGateL") && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("OpenGateR") && canPlay)
        {
            StartCoroutine("OpenSound");
        }

        if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName("CloseGateL") && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("CloseGateR") && canPlay)
        {
            StartCoroutine("CloseSound");
        }
    }

    IEnumerator OpenSound()
    {
        audiosource.PlayOneShot(dooropen);
        canPlay = false;

        yield return new WaitForSeconds(3f);

        canPlay = true;
    }

    IEnumerator CloseSound()
    {
        audiosource.PlayOneShot(doorclose);
        canPlay = false;

        yield return new WaitForSeconds(3f);

        canPlay = true;
    }
}
