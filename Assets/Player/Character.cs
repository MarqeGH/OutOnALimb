using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class Character : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float gravityValue = -9.81f;
    [SerializeField] float controllerDeadzone = 0.1f;
    [SerializeField] float gamepadRotateSmoothing = 1000f;
    [SerializeField] bool isGamepad;
    Animator animator;

    private CharacterController characterController;

    private Vector2 movement;
    private Vector2 aim;

    Transform cam;
    Vector3 camForward;
    Vector3 moveanim;
    Vector3 moveInput;

    float forwardAmount;
    float turnAmount;
    
    private Vector3 playerVelocity;

    private PlayerControls playerControls;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
    }
    void Start()
    {
        SetupAnimator();
        cam = Camera.main.transform;
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
    }

    void HandleInput()
    {
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();
        aim = playerControls.Controls.Aim.ReadValue<Vector2>();
        HandleMoveAnimations();
    }

    private void HandleMoveAnimations()
    {
        Debug.Log(cam);
        if (cam != null)
        {
            camForward = Vector3.Scale(cam.forward, new Vector3(1, -15, 0).normalized);
            moveanim = movement.y * camForward + movement.x * cam.right;
        }
        else
        {
            moveanim = movement.y * Vector3.forward + movement.x * Vector3.right;
        }

        if (moveanim.magnitude > 1)
        {
            moveanim.Normalize();
        }
        MoveCharacter(moveanim);
    }

    void MoveCharacter(Vector3 move)
    {
        if (move.magnitude > 1)
        {
            move.Normalize();
        }
        this.moveInput = move;

        ConvertMoveInput();
        UpdateAnimator();
    }

    void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        Debug.Log(localMove);
        turnAmount = localMove.x;
        forwardAmount = localMove.y;
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        characterController.Move(move * Time.deltaTime * speed);

        playerVelocity.y += gravityValue*Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime*1);
    }
    void HandleRotation()
    {
        if (isGamepad)
        {
            // rotate player
            if (Math.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if(groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

        private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    void SetupAnimator()
    {
        animator = GetComponent<Animator>();

        foreach (var childAnimator in GetComponentsInChildren<Animator>())
        {
            if (childAnimator != animator)
            {
                animator.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }




}
