using UnityEngine;

public class EnemyPlayerSearch : MonoBehaviour
{
    [Header("Search Settings")]
    public Transform player;

    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Detection Settings")]
    public float detectionRange = 15f;  
    public float attackRange = 8f;

    void Update()
    {
        if (player == null)
        {
    
            return;
        }
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
           
            return;
        }
            if (distance <= attackRange)
            {
                return;
            }

            MoveTowardPlayer();
        }

        void MoveTowardPlayer()
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
