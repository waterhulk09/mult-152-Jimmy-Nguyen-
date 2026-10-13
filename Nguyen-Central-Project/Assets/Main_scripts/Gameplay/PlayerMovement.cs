using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public InputActionReference moveAction;
    public PlayerTargeting targeting;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Transform camTransform;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (Camera.main != null)
        {
            camTransform = Camera.main.transform;
        }
    }

    void OnEnable()
    {
        moveAction?.action?.Enable();
    }

    void OnDisable()
    {
        moveAction?.action?.Disable();
    }

    void Update()
    {
        if (moveAction != null && moveAction.action != null)
        {
            moveInput = moveAction.action.ReadValue<Vector2>();
        }

        // Handle target locking rotation smoothly
        if (targeting != null && targeting.IsLockedOn && targeting.LockedTarget != null)
        {
            Vector3 direction = targeting.LockedTarget.transform.position - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 8f * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // Align movement direction with the camera's orientation
        Vector3 forward = camTransform != null ? camTransform.forward : Vector3.forward;
        Vector3 right = camTransform != null ? camTransform.right : Vector3.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveInput.y + right * moveInput.x);
        Vector3 targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);
    }
}