using UnityEngine;
using UnityEngine.UI;

public class Herohp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBarImage; // 체력 바 이미지

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }

    void Die()
    {
        Debug.Log("히어로 사망");
        // 게임 오버 처리
    }
}