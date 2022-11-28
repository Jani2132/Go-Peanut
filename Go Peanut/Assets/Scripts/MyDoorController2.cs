using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController2 : MonoBehaviour
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
        if (doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("ClosedBackDoor") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("ClosedFrontDoor"))
        {
            doorOpen = false;
        }

        if (doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("OpenedBackDoor") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("OpenedFrontDoor"))
        {
            doorOpen = true;
        }
    }

    public void PlayAnimation2()
    {
        if (!doorOpen && canInteract && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("ClosedBackDoor") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("ClosedFrontDoor"))
        {
            StartCoroutine("Open");
            canInteract = false;
            StartCoroutine("Opened");

        }

        if (doorOpen && canInteract && doorAnim2.GetCurrentAnimatorStateInfo(0).IsName("OpenedBackDoor") && doorAnim.GetCurrentAnimatorStateInfo(0).IsName("OpenedFrontDoor"))
        {
            StartCoroutine("Close");
            canInteract = false;
            StartCoroutine("Closed");
        }
    }

    IEnumerator Opened()
    {
        yield return new WaitForSeconds(2f);
        doorOpen = true;
        canInteract = true;
    }

    IEnumerator Closed()
    {
        yield return new WaitForSeconds(2f);
        doorOpen = false;
        canInteract = true;
    }

    IEnumerator Open()
    {
        doorAnim.Play("OpenFrontDoor", 0, 0.0f);
        doorAnim2.Play("OpenBackDoor", 0, 0.0f);

        yield return new WaitForSeconds(2f);

        doorAnim.Play("OpenedFrontDoor", 0, 0.0f);
        doorAnim2.Play("OpenedBackDoor", 0, 0.0f);
    }

    IEnumerator Close()
    {
        doorAnim.Play("CloseFrontDoor", 0, 0.0f);
        doorAnim2.Play("CloseBackDoor", 0, 0.0f);

        yield return new WaitForSeconds(2f);

        doorAnim.Play("ClosedFrontDoor", 0, 0.0f);
        doorAnim2.Play("ClosedBackDoor", 0, 0.0f);

    }
}
