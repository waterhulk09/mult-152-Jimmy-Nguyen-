using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public InputActionReference moveAction;

    public PlayerTargeting targeting;

    [SerializeField] private Transform moveReference;

    void Update()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();

        float horizontal = move.x;
        float vertical = move.y;

        Vector3 forward;
        Vector3 right;

        if (targeting != null && targeting.IsLockedOn && targeting.LockedTarget != null)
        {
            forward = transform.forward;
            right = transform.right;
        }
        else
        {
            forward = moveReference.forward;
            right = moveReference.right;
        }

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * vertical + right * horizontal;
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (targeting != null && targeting.IsLockedOn && targeting.LockedTarget != null)
        {
            Vector3 direction = targeting.LockedTarget.transform.position - transform.position;

            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 8f * Time.deltaTime);
            }
        }

        else if (movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}