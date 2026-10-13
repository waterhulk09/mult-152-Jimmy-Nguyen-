using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int health = 50;
    public int maxHealth = 50;

    void Start()
    {
        health = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;

        Debug.Log(gameObject.name + "took " + damage + " damage. ");

        if (health <= 0)
        {
            Debug.Log(gameObject.name + " died");
            Destroy(gameObject);
        }
    }
}