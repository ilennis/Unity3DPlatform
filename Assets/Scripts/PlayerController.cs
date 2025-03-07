using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
     private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    private RaycastHit hi;
    private Ray ray;
    private GameObject rayObject;
  

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // 게임 한가운데로 고정
    }
    private void Update()
    {
        if (_rigidbody.velocity.y < 0)
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * 1.5f * Time.deltaTime; // -y velocity가 있으면, 더 빨리 떨어지게 적용
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        CameraLook();
    }
    // Update is called once per frame
    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }
    public void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook); // 위에 반복해서 min/max 값 사이에 가능하도록 고정
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); // rotation 값 - 는 마우스 값이랑 +, - 상반되어서.

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }
    public void OnLook(InputAction.CallbackContext context) // 마우스로 카메라
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * 5, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector2.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector2.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector2.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector2.down)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if(Physics.Raycast(rays[i], 0.5f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jumper"))
        {
            _rigidbody.AddForce(Vector2.up * 20, ForceMode.Impulse);
        }
    }

    public void ModifySpeed(float multiplier)
    {
        moveSpeed *= multiplier; // Adjust the speed
    }
    public float Speed()
    {
        float speed = _rigidbody.velocity.magnitude;
        return speed;
    }
}
