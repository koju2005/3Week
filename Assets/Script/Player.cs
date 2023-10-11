using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;
    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;
    private bool Timebool;
    public static PlayerController instance;

    private Vector3 curSavePoint = Vector3.zero;
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

        }
    }

    public void OnSaveInput(InputAction.CallbackContext val)
    {
        if(val.phase == InputActionPhase.Started)
        {
            transform.position = curSavePoint;
        }
    }
    public void OnTimeInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if(Timebool == false)
            {
              Time.timeScale = 0.15f;
              Time.fixedDeltaTime = Time.timeScale * 0.02f;
                Timebool = true;
            }
         
           else if(Timebool == true)
            {
                Time.timeScale = 1;
                Timebool = false;
            }
          
        }
    }
    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
             {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
             };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            curSavePoint = collision.transform.position;
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.layer == 8)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce*5, ForceMode.Impulse);
        }
    }

}