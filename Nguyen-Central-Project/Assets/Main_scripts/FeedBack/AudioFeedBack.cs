using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip damageClip;
    public AudioClip deathClip;

    private Health playerHealth;
    private EnemyHealth enemyHealth;

    private int lastHealth;
    private bool isInitialized = false;

    void OnEnable()
    {
        playerHealth = GetComponentInParent<Health>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += HandleHealthChanged;
            lastHealth = playerHealth.currentHealth;
            isInitialized = true;
        }

        enemyHealth = GetComponentInParent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged += HandleHealthChanged;
            lastHealth = enemyHealth.health;
            isInitialized = true;
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= HandleHealthChanged;
        }

        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged -= HandleHealthChanged;
        }
    }

    void HandleHealthChanged(int currentHealth)
    {
        if (!isInitialized)
        {
            lastHealth = currentHealth;
            isInitialized = true;
            return;
        }

        // Only play damage sound if health actually went down
        if (currentHealth < lastHealth && currentHealth > 0)
        {
            if (audioSource != null && damageClip != null)
            {
                audioSource.PlayOneShot(damageClip);
            }
        }
        // Only play death sound if health dropped to 0 or below
        else if (currentHealth <= 0 && lastHealth > 0)
        {
            if (deathClip != null)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
        }

        lastHealth = currentHealth;
    }
}