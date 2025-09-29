using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f; // 몬스터의 최대 체력
    private float currentHealth; // 몬스터의 현재 체력

    [SerializeField] private Image healthBarImage; // (선택 사항) 몬스터 체력바 UI 이미지
    [SerializeField] private GameObject healthBarCanvas; // (선택 사항) 체력바를 담고 있는 캔버스 (활성화/비활성화를 위함)

    void Start()
    {
        currentHealth = maxHealth; 
        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(false); 
        }
        UpdateHealthBar(); 
    }

    // 몬스터 체력 감소 함수
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 현재 체력에서 데미지를 감소시킵니다.

        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(true); // 데미지를 입으면 체력바를 활성화합니다.
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0; 
            Die(); 
        }
        UpdateHealthBar(); 
    }

    // (선택 사항) 몬스터 체력 회복 함수 (몬스터에게 필요 없는 경우가 많지만, 필요하면 사용)
    public void Heal(float amount)
    {
        currentHealth += amount; // 현재 체력에 회복량을 더합니다.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // 최대 체력을 초과하지 않도록 합니다.
        }
        UpdateHealthBar(); // 체력바를 업데이트합니다.
    }

    // 몬스터 체력바 UI 업데이트 함수
    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    // 몬스터 사망 처리 함수
    private void Die()
    {
        Debug.Log(gameObject.name + " 몬스터가 사망했습니다!");
        Destroy(gameObject); // 몬스터 게임 오브젝트를 파괴하는 예시
    }
}
