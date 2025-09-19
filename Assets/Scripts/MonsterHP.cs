using UnityEngine;
using UnityEngine.UI; // 몬스터 체력바 UI를 사용할 경우 필요합니다.
using System.Collections; // 코루틴을 사용하기 위해 필요합니다 (선택 사항).

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f; // 몬스터의 최대 체력
    private float currentHealth; // 몬스터의 현재 체력

    [SerializeField] private Image healthBarImage; // (선택 사항) 몬스터 체력바 UI 이미지
    [SerializeField] private GameObject healthBarCanvas; // (선택 사항) 체력바를 담고 있는 캔버스 (활성화/비활성화를 위함)

    void Start()
    {
        currentHealth = maxHealth; // 게임 시작 시 현재 체력을 최대 체력으로 설정합니다.
        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(false); // 초기에는 체력바를 비활성화합니다.
        }
        UpdateHealthBar(); // 초기 체력바를 업데이트합니다.
    }

    // 몬스터 체력 감소 함수
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 현재 체력에서 데미지를 감소시킵니다.

        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(true); // 데미지를 입으면 체력바를 활성화합니다.
            // 일정 시간 후 체력바를 비활성화하는 코루틴을 사용할 수도 있습니다.
            // 아래 주석 해제하여 사용 가능
            // StopAllCoroutines(); // 기존 코루틴 중단
            // StartCoroutine(HideHealthBarAfterDelay(3f)); // 3초 후 체력바 숨기기 예시
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0; // 체력이 0 이하가 되지 않도록 방지
            Die(); // 체력이 0 이하가 되면 몬스터를 죽입니다.
        }
        UpdateHealthBar(); // 체력바를 업데이트합니다.
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
        // 여기에 몬스터 사망 애니메이션, 아이템 드롭, 오브젝트 비활성화 또는 파괴 등의 로직을 추가합니다.
        Destroy(gameObject); // 몬스터 게임 오브젝트를 파괴하는 예시
    }

    // (선택 사항) 일정 시간 후 체력바를 숨기는 코루틴
    /*
    private IEnumerator HideHealthBarAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(false);
        }
    }
    */
}
