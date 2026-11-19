using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    public InputActionReference throwAction;
    public PlayerGrab playerGrab;
    public float throwForce = 20f;

    [Header("Animation")]
    public Animator animator;
    public string throwTriggerName = "Throw";

    private void OnEnable()
    {
        if (throwAction != null && throwAction.action != null)
        {
            throwAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (throwAction != null && throwAction.action != null)
        {
            throwAction.action.Disable();
        }
    }

    private void Update()
    {
        if (throwAction != null && throwAction.action != null && throwAction.action.triggered)
        {
            ThrowObject();
        }
    }

    private void ThrowObject()
    {
        if (playerGrab == null || playerGrab.HeldObject == null)
        {
            Debug.Log("No Object held");
            return;
        }

        GrabObject item = playerGrab.HeldObject.GetComponent<GrabObject>();
        if (item == null || !item.canbeThrown)
        {
            Debug.Log((item != null ? item.itemName : "Object") + " Can't be thrown");
            return;
        }

        Rigidbody rb = playerGrab.HeldObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("Object has no RB!");
            return;
        }

        if (animator != null && !string.IsNullOrEmpty(throwTriggerName))
        {
            animator.ResetTrigger(throwTriggerName);
            animator.SetTrigger(throwTriggerName);
        }

        playerGrab.ReleaseHeldObject();

        rb.isKinematic = false;
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}