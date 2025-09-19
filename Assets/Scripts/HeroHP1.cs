using UnityEngine;
using UnityEngine.UI; // UI 요소를 사용하기 위해 필요합니다.

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // 최대 체력
    private float currentHealth; // 현재 체력

    [SerializeField] private Image healthBarImage; // 체력바 이미지 UI

    void Start()
    {
        currentHealth = maxHealth; // 게임 시작 시 현재 체력을 최대 체력으로 설정합니다.
        UpdateHealthBar(); // 초기 체력바를 업데이트합니다.
    }

    // Update는 여기서는 필수는 아니지만, 테스트를 위해 넣을 수 있습니다.
    // void Update()
    // {
    //     // 예시: 스페이스바를 누르면 데미지를 입는 기능 (테스트용)
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(10);
    //     }
    //     // 예시: Q 키를 누르면 회복하는 기능 (테스트용)
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         Heal(5);
    //     }
    // }

    // 체력 감소 함수
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 현재 체력에서 데미지를 감소시킵니다.
        if (currentHealth <= 0)
        {
            currentHealth = 0; // 체력이 0 이하가 되지 않도록 방지
            Die(); // 체력이 0 이하가 되면 플레이어를 죽입니다.
        }
        UpdateHealthBar(); // 체력바를 업데이트합니다.
    }

    // 체력 회복 함수
    public void Heal(float amount)
    {
        currentHealth += amount; // 현재 체력에 회복량을 더합니다.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // 최대 체력을 초과하지 않도록 합니다.
        }
        UpdateHealthBar(); // 체력바를 업데이트합니다.
    }

    // 체력바 UI 업데이트 함수
    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            // 현재 체력 / 최대 체력 비율로 fillAmount를 설정합니다.
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    // 플레이어 사망 처리 함수
    private void Die()
    {
        Debug.Log("플레이어가 사망했습니다!");
        // 여기에 플레이어 사망 애니메이션, 게임 오버 처리 등의 로직을 추가합니다.
        // 예를 들어: Destroy(gameObject); 또는 SceneManager.LoadScene("GameOverScene");
    }
}
