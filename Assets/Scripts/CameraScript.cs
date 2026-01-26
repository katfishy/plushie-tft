using UnityEngine;
using UnityEngine.InputSystem;

public class FreeLookCamera : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float sprintSpeed = 25f;
    public float verticalSpeed = 5f;

    [Header("Look")]
    public float mouseSensitivity = 0.2f;
    public float maxPitch = 90f;

    private float yaw;
    private float pitch;

    private bool isLooking;

    void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Keyboard.current == null) return;

        float speed = Keyboard.current.leftShiftKey.isPressed
            ? sprintSpeed
            : moveSpeed;

        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) move += transform.forward;
        if (Keyboard.current.sKey.isPressed) move -= transform.forward;
        if (Keyboard.current.aKey.isPressed) move -= transform.right;
        if (Keyboard.current.dKey.isPressed) move += transform.right;

        if (Keyboard.current.qKey.isPressed) move -= Vector3.up * verticalSpeed;
        if (Keyboard.current.eKey.isPressed) move += Vector3.up * verticalSpeed;

        transform.position += move.normalized * speed * Time.deltaTime;
    }

    void HandleLook()
    {
        if (Mouse.current == null) return;

        // RMB press → start looking
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isLooking = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // RMB release → stop looking
        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            isLooking = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!isLooking) return;

        Vector2 delta = Mouse.current.delta.ReadValue();

        yaw += delta.x * mouseSensitivity;
        pitch -= delta.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
