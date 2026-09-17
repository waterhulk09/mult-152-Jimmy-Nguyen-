using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to pick up the item");
        }
    }

private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
           Debug.Log("Player has dropped the object");
        }
         

    }

}
