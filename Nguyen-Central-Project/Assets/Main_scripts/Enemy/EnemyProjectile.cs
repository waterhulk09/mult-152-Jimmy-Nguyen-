using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
   public int damage = 10;

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
