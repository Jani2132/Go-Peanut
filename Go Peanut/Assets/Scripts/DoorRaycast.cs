using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] public int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    public MyDoorController raycastedObj;
    public MyDoorController2 raycastedObj2;

    public GameObject BodyRC;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private bool isCrossHairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";

    public bool ThirdPerson;

    public Transform camHolder2;


    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.back);

            int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {

                        raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                        raycastedObj2 = hit.collider.gameObject.GetComponent<MyDoorController2>();


                    if (Input.GetKeyDown(openDoorKey) && hit.collider.gameObject.name == "ContDoorRight")
                    {
                        raycastedObj.PlayAnimation();
                    }

                    if (Input.GetKeyDown(openDoorKey) && hit.collider.gameObject.name == "ContDoorLeft")
                    {
                        raycastedObj.PlayAnimation();
                    }


                    if (Input.GetKeyDown(openDoorKey) && hit.collider.gameObject.name == "ButtonFront")
                    {
                        raycastedObj2.PlayAnimation2();
                    }

                    if (Input.GetKeyDown(openDoorKey) && hit.collider.gameObject.name == "ButtonBack")
                    {
                        raycastedObj2.PlayAnimation2();
                    }
                }
            }


            else
            {
                if (isCrossHairActive)
                {
                    doOnce = false;
                }
            }

            Debug.DrawRay(transform.position, fwd, Color.blue, rayLength);
        }       
    }
}
