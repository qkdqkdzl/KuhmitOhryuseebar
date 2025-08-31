using UnityEngine;
/// <summary>
/// 플레이어가 밟으면 애너미들이 반응하게 만들어 주는 스크립트
/// </summary>
public class TriggerZone : MonoBehaviour
{
    [SerializeField] private EnemyController enemyManager; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyManager.CommandAllEnemiesToMove(other.transform);
        }
    }
}

