using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Slider healthSlider;
   public int maxHealth = 100;
   public int currentHealth;




void Start()

    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
         
         if (currentHealth <= 0)
        {
            Death();
        }
        
        if (healthSlider != null)
{
    healthSlider.value = currentHealth;
}
    }

 void Death()
    {

        Debug.Log(gameObject.name + " You are dead as hell."); 
        Destroy(gameObject);
    }
}

