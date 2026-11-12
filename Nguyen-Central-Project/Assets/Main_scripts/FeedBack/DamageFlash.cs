using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    Color originalColor;

    private Health playerHealth;
    private EnemyHealth enemyHealth;

    void Start()
    {
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    void OnEnable()
    {
        playerHealth = GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += Flash;
        }

        enemyHealth = GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged += Flash;
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= Flash;
        }

        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged -= Flash;
        }
    }

    void Flash(int currentHealth)
    {
        if (currentHealth > 0)
        {
            StopAllCoroutines();
            StartCoroutine(FlashRoutine());
        }
    }

    System.Collections.IEnumerator FlashRoutine()
    {
        targetRenderer.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        targetRenderer.material.color = originalColor;
    }
}