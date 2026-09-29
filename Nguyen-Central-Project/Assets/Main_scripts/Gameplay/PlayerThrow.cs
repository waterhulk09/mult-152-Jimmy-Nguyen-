using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerThrow : MonoBehaviour
{
    public InputActionReference throwAction;

    public PlayerGrab playerGrab;


    public float throwForce =20f;

    void Update()
    {
        if (throwAction.action.triggered)
        {
            ThrowObject();
        }
    }


void ThrowObject()
{
        /*if (playerGrab.HeldObject == null) return;
    
    GrabObject item = playerGrab.HeldObject.GetComponent<GrabObject>();

if (!item.canbeThrown) return;

Rigidbody rb = playerGrab.HeldObject.GetComponent<Rigidbody>();



playerGrab.ReleaseHeldObject();


if (rb = null) return;

 rb.isKinematic = false;

 Vector3 throwDirection;

throwDirection = transform.forward;

rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);*/
   

    if (playerGrab.HeldObject == null) 
    {
    Debug.Log("No Object held");
    return;
        } 


    GrabObject item = playerGrab.HeldObject.GetComponent<GrabObject>();

    if (!item.canbeThrown)
    {
        Debug.Log(item.itemName + " Can't be thrown");
        return;
    }
    Rigidbody rb = playerGrab.HeldObject.GetComponent<Rigidbody>();

    if(rb == null)
    {
        Debug.Log("Object has no RB!");
        return;

    }
    playerGrab.ReleaseHeldObject();

    rb.isKinematic = false;
    rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
