using UnityEngine;
using UnityEngine.InputSystem;
public class TPCam : MonoBehaviour
{
    [Header("References")]
    public Transform target;
    public InputActionReference lookAction;
    [Header("Camera Settings")]
    public float distance = 6f;
    public float height = 3f;
    public float rotationSpeed = 120f;
    [Header("Pitch Limits")]
    public float minPitch = -30f;
    public float maxPitch = 60f;
    private float currentYaw;
    private float currentPitch = 20f;
    private void OnEnable()
    {
        lookAction.action.Enable();
    }
    private void OnDisable()
    {
        lookAction.action.Disable();
    }
    void LateUpdate()
    {
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();
        currentYaw += lookInput.x * rotationSpeed * Time.deltaTime;
        currentPitch -= lookInput.y * rotationSpeed * Time.deltaTime;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        Quaternion rotation =
            Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 offset =
            rotation * new Vector3(0f, 0f, -distance);
        transform.position =
            target.position +
            Vector3.up * height +
            offset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}