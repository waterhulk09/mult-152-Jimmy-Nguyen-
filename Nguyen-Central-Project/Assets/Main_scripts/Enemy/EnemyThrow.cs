using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    [Header("Connections")]
    public Transform player;
    public GameObject rockPrefab;
    public Transform throwPoint;

    [Header("Throwing Settings")]
    public float throwForce = 15f;
    public float attackRange = 8f;
    public float attackCooldown = 9f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && timer >= attackCooldown)
        {
            ThrowProjectile();
            timer = 0f;
        }
    }

    void ThrowProjectile()
    {
        GameObject projectile = Instantiate(rockPrefab, throwPoint.position, Quaternion.identity);
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 direction = (player.position - throwPoint.position).normalized;
        
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
    }
}
