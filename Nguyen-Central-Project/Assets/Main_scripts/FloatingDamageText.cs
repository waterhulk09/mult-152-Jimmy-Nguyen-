using UnityEngine;
using TMPro;
public class FloatingDamageText : MonoBehaviour
{
public float moveSpeed = 2f;
public float lifeTime = 1.5f;

private TextMeshProUGUI damageText;


private void Awake()
    {
       damageText = GetComponent<TextMeshProUGUI>();
    }

    public void SetDamage()
    {
        damageText.text = damageText.ToString();
    }

    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

}
