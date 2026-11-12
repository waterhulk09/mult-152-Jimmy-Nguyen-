using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Settings")]
    public Slider healthSlider;
    public int health = 50;
    public int maxHealth = 50;

    [Header("Text Damage")]
    public GameObject damageTextPrefab;
    public Transform damageTextSpawnPoint;

    // Event that AudioFeedback and DamageFlash can listen to
    public event System.Action<int> OnHealthChanged;

    void Start()
    {
        health = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        ShowDamageText(damage);

        // Notify any subscribed scripts (like AudioFeedback and DamageFlash)
        OnHealthChanged?.Invoke(health);

        Debug.Log(gameObject.name + " took " + damage + " damage.");

        if (health <= 0)
        {
            Debug.Log(gameObject.name + " died");
            Destroy(gameObject);
        }
    }

    void ShowDamageText(int damage)
    {
        if (damageTextPrefab == null || damageTextSpawnPoint == null)
        {
            return;
        }

        GameObject text = Instantiate(damageTextPrefab, damageTextSpawnPoint.position, Quaternion.identity);

        FloatingDamageText floatingText = text.GetComponent<FloatingDamageText>();

        if (floatingText != null)
        {
            floatingText.SetDamage(damage);
        }
    }
}