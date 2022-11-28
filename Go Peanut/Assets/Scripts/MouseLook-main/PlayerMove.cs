using TMPro;
using UnityEngine;
using UnityTemplateProjects;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private MoveSettings _settings = null;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    private Rigidbody body;

    public float isGroundedDistance = 0.01f;
    public float gravity = 9.8f;
    public float cooldownTime = 3.5f;

    public bool isWalking;
    public bool didItPlay = false;
    public bool inCooldown;

    [Range(0.0f, 100.0f)]
    public float pushPower = 2;

    //Sound

    public AudioClip bonkSound;
    public AudioSource bonkSource;

    public AudioClip[] jumpSound;
    public AudioSource jumpSource;

    private float groundedClock = 0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Debug.Log(isWalking);
        Debug.Log(_controller.isGrounded);
    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * Time.deltaTime);
        _controller.SimpleMove(Vector3.forward * 0);
        DefaultMovement();
        JumpSoundLimit();
    }
    private void DefaultMovement()
    {
        if (_controller.isGrounded)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * _settings.speed;
            _moveDirection.z = input.y * _settings.speed;
            _moveDirection.y = -_settings.antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * _settings.speed;
            _moveDirection.z = input.y * _settings.speed;
            _moveDirection.y -= _settings.gravity * Time.deltaTime;

            _moveDirection = transform.TransformDirection(_moveDirection);
        }
        Vector3 inputb = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));;

        inputb.x = Input.GetAxis("Horizontal");
        inputb.z = Input.GetAxis("Vertical");

        if (inputb.x != 0 || inputb.z != 0 && _controller.isGrounded && groundedClock > 0.01f)
        {
            isWalking = true;
        }
        else
            isWalking = false;

        if (_controller.isGrounded == false)
        {
            isWalking = false;
        }
    }

    private void Jump()
    {
        _moveDirection.y += _settings.jumpForce;
        jumpSource.clip = jumpSound[Random.Range(0, jumpSound.Length)];
        jumpSource.Play();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        body = hit.collider.attachedRigidbody;

        if (pushPower >= 60 && !inCooldown && body)
        {
            StartCoroutine(playSound());
            bonkSource.Stop();
        }


        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }
        
        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.
        // Apply the push
        body.velocity = pushDir * pushPower;
    }

    IEnumerator playSound()
    {
        bonkSource.PlayOneShot(bonkSound);
        bonkSource.Stop();
        inCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }

    void JumpSoundLimit()
    {

        if (_controller.isGrounded)
        {
            groundedClock += Time.deltaTime;
        }
        else
        {
            groundedClock = 0f;
        }
    }
}
