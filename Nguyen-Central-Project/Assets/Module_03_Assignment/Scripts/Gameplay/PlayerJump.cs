using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpHeight = 8f;


    [Header("Input")]
    public InputActionReference jumpAction;

    [Header("is on Ground")]

    public Transform groundCheck;
    public float groundDistance = 0.25f;
    public LayerMask groundLayer;

    [Header("Weight Setting")]
    public PlayerGrab playerGrab;

    private Rigidbody rb;
    private bool isGrounded;
    public float jumpForce = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (jumpAction.action.triggered && isGrounded)
        {
            Jump();
        }
    }
       void Jump()
    {
        float finalJumpForce = jumpForce;

        if (playerGrab.carriedWeight > 0)
        {
            finalJumpForce -= playerGrab.carriedWeight * 0.1f;
        }
   
        finalJumpForce = Mathf.Max(finalJumpForce, 2f);

        rb.AddForce(Vector3.up * finalJumpForce, ForceMode.Impulse);
    }

}

