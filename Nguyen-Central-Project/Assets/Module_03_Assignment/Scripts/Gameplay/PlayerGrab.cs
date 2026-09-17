using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerGrab : MonoBehaviour
{
   public InputActionReference grabAction;

   public Transform holdPoint;
public float carriedWeight = 0f;
   private GameObject heldObject;

    void Update()
    {
        if (grabAction.action.triggered)
        {
            if (heldObject == null)
            {
                TryGrab();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryGrab()
    {
        Collider[] nearbyObject = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider col in nearbyObject)
        {
            GrabObject grabObject = col.GetComponent<GrabObject>();

            if (grabObject != null && grabObject.playerInRange)
            {
                heldObject = col.gameObject;

               GrabObject grabData = heldObject.GetComponent<GrabObject>();
               carriedWeight = grabData.weight;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = true;
                }
        
        heldObject.transform.SetParent(holdPoint);
         heldObject.transform.localPosition = Vector3.zero;

         return;
            }
        }
    }

void DropObject()

    {
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        heldObject.transform.SetParent(null);

        if(rb != null)
        {
            rb.isKinematic = false;
        
        }
     carriedWeight = 0f;
        heldObject = null;
    }
}
