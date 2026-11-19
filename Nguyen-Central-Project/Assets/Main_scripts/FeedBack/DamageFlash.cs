using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private Color originalColor;
    private Health playerHealth;
    private EnemyHealth enemyHealth;

    private int lastHealth;
    private bool isInitialized = false;

    void Start()
    {
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

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

        // Only flash when health actually decreases
        if (currentHealth < lastHealth && currentHealth > 0)
        {
            if (targetRenderer != null)
            {
                StopAllCoroutines();
                StartCoroutine(FlashRoutine());
            }
        }

        lastHealth = currentHealth;
    }

    System.Collections.IEnumerator FlashRoutine()
    {
        targetRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        targetRenderer.material.color = originalColor;
    }
}