using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerJump playerJump;
    [SerializeField] private PlayerMovement movement;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        if (animator == null)
        {
            return;
        }

        UpdateGroundingAnimation();
        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        if (Time.deltaTime <= 0f)
        {
            return;
        }

        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        velocity.y = 0f;
        float speed = velocity.magnitude;

        animator.SetFloat("Speed", speed);
        lastPosition = transform.position;
    }

    private void UpdateGroundingAnimation()
    {
        if (playerJump == null)
        {
            return;
        }

        animator.SetBool("Grounded", playerJump.IsGrounded);
    }
}