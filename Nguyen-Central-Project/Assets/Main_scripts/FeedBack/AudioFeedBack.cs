using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip damageClip;
    public AudioClip deathClip;

    private Health playerHealth;
    private EnemyHealth enemyHealth;

    void OnEnable()
    {
    
        playerHealth = GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += OnHealthChanged;
        }

        enemyHealth = GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged += OnHealthChanged;
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= OnHealthChanged;
        }

        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged -= OnHealthChanged;
        }
    }

    void OnHealthChanged(int currentHealth)
    {
        if (currentHealth > 0)
        {
            audioSource.PlayOneShot(damageClip);
        }
        else
        {
            audioSource.PlayOneShot(deathClip);
        }
    }
}