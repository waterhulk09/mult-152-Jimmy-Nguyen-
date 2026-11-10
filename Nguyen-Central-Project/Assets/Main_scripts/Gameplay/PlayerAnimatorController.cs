using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    private Vector3 lastPosition;

    void Update()
    {
       Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
       velocity.y = 0f; 

       animator.SetFloat("Speed", velocity.magnitude); 
       lastPosition = transform.position;
    }

    public void PlayThrow()
    {
        animator.SetTrigger("Throw");
    }

    public void SetJumping(bool jumping)
    {
        animator.SetBool("Jump", jumping);
    }
}
