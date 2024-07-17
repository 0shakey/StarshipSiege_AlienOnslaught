using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

public class PlayerMovement : MonoBehaviour
{
    public PlayerControls inputActions;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float x;
    public float z;
    public float xRotation = 0.0f;
    public float mouseSensitivity = 300.0f;
    public Transform playerBody;
    public Transform cameraTransform;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.gameplay.Enable();
        inputActions.gameplay.move.performed += value => Move(value);
        inputActions.gameplay.move.canceled += value => Move(value);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Initialize xRotation to the current camera rotation
        xRotation = cameraTransform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void Move(UnityEngine.InputSystem.InputAction.CallbackContext value)
    {
        Debug.Log(value.ReadValue<Vector2>());
        if (value.started)
        {
            Debug.Log("Started");
           
        }
        else if (value.performed)
        {
            Debug.Log("Performed");
            x = value.ReadValue<Vector2>().x;
            z = value.ReadValue<Vector2>().y;
        }
        else if (value.canceled)
        {
            Debug.Log("Canceled");
            x = value.ReadValue<Vector2>().x;
            z = value.ReadValue<Vector2>().y;
        }
    }
}
