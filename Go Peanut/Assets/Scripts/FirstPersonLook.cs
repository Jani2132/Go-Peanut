using System;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{

    [SerializeField] bool lockCursor = true;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    [SerializeField] float clampAmount = 80f;

    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    float xRotation = 0f;


    Vector2 rotation;


    // Assign this if there's a parent object controlling motion, such as a Character Controller.
    // Yaw rotation will affect this object instead of the camera if set.
    public GameObject characterBody;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }


            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -clampAmount, clampAmount);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            characterBody.transform.Rotate(Vector3.up * mouseX);
        }
    }


}
