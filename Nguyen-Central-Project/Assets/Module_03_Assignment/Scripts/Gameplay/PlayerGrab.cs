using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerGrab : MonoBehaviour
{
   public InputActionReference grabAction;

   public Transform holdPoint;
   private GameObject heldObject;

public string carriedItemName = "Nothing";
public float carriedWeight = 0f;
 
 [HideInInspector]

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

            carriedItemName = grabObject.ItemName;
            carriedWeight = grabObject.weight;

            if (grabObject != null && grabObject.playerInRange)
            {
                heldObject = col.gameObject;

               GrabObject grabData = heldObject.GetComponent<GrabObject>();
               carriedItemName = grabObject.ItemName;
               carriedWeight = grabObject.weight;

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
     
     
        heldObject = null;
        carriedItemName = "Nothing";
         carriedWeight = 0f;
    }
}
