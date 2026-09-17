using UnityEngine;

public class GrabObject : MonoBehaviour
{

[Header ("Object Weight")]
public float weight = 10f;

[HideInInspector]
public bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("press E to pick up");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player Dropped Object");
        }
    }
}
