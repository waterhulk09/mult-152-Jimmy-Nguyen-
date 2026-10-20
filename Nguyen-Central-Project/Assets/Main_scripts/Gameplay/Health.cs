using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Health Bar")]
    public Slider healthSlider;
    public Image healthFill;
    
  public TMP_Text healthText;

    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        healthFill.color = Color.green;

        UpdateHealthUI();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
        
        if (currentHealth <= 0)
        {
            Death();
        }
    }

private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
        healthText.text = "HP " +currentHealth + " / " + maxHealth;
         healthFill.color = Color.Lerp(Color.red, Color.green,currentHealth/(float)maxHealth);
    }


    void Death()
    {
        Debug.Log(gameObject.name + " You are dead as hell.");
        Destroy(gameObject);
    }
}
