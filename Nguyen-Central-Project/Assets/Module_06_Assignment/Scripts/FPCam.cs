using UnityEngine;
using UnityEngine.InputSystem;
public class FPCam : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody;
    public InputActionReference lookAction;
    [Header("Camera Settings")]
    public float lookSensitivity = 100f;
    public float minPitch = -80f;
    public float maxPitch = 80f;
    private float pitch = 0f;
    private void OnEnable()
    {
        lookAction.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        lookAction.action.Disable();
    }
    void Update()
    {
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();
        float mouseX = lookInput.x * lookSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * lookSensitivity * Time.deltaTime;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}