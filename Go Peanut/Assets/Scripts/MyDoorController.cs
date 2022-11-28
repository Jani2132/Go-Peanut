using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;

    public GameObject door2;
    public Animator doorAnim2;

    public bool doorOpen = false;
    public bool canInteract = true;

    private void Awake()
    {
        doorAnim = door.GetComponent<Animator>();
        doorAnim2 = door2.GetComponent<Animator>();
    }

    private void Update()
    {
        if (doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("ClosedGateR") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("ClosedGateL"))
        {
            doorOpen = false;
        }

        if (doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("OpenedGateR") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("OpenedGateL"))
        {
            doorOpen = true;
        }
    }

    public void PlayAnimation()
    {
        if(!doorOpen && canInteract && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("ClosedGateR") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("ClosedGateL"))
        {
            StartCoroutine("Open");
            canInteract = false;
            StartCoroutine("Opened");
            
        }
        
        if(doorOpen && canInteract && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("OpenedGateR") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("OpenedGateL"))
        {
            StartCoroutine("Close");
            canInteract = false;
            StartCoroutine("Closed");
        }
    }

    IEnumerator Opened()
    {
        yield return new WaitForSeconds(3f);
        doorOpen = true;
        canInteract = true;
    }

    IEnumerator Closed()
    {
        yield return new WaitForSeconds(3f);
        doorOpen = false;
        canInteract = true;
    }

    IEnumerator Open()
    {
        doorAnim.Play("OpenGateL", 0, 0.0f);
        doorAnim2.Play("OpenGateR", 0, 0.0f);

        yield return new WaitForSeconds(3f);

        doorAnim.Play("OpenedGateL", 0, 0.0f);
        doorAnim2.Play("OpenedGateR", 0, 0.0f);
    }

    IEnumerator Close()
    {
        doorAnim.Play("CloseGateL", 0, 0.0f);
        doorAnim2.Play("CloseGateR", 0, 0.0f);

        yield return new WaitForSeconds(3f);

        doorAnim.Play("ClosedGateL", 0, 0.0f);
        doorAnim2.Play("ClosedGateR", 0, 0.0f);

    }
}
