using UnityEngine;
using TMPro;
public class FloatingDamageText : MonoBehaviour
{
public float moveSpeed = 2f;
public float lifeTime = 1.5f;

private TextMeshProUGUI damageText;

public void SetDamage(int damage)
    {
        damageText.text = damage.ToString();
    }

private void Awake()
    {
       damageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setDamage(int damage)
    { 
        damageText.text = damage.ToString();
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}

