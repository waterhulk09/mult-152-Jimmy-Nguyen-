using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
     public float moveSpeed = 5f;
     public InputActionReference moveAction;


    void Update()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();

float horizontal = move.x;
float vertical = move.y;

Vector3 movement =
    transform.forward * vertical + transform.right * horizontal;
transform.position += movement * moveSpeed * Time.deltaTime;
    
    //Debug.Log("Move: " + move + "| Player Position: " + transform.position);
    }
}
