using UnityEngine;


/// <summary>
/// 애너미가 플레이어를 향해 움직일 수 있게 해주는 스크립트
/// </summary>

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyController[] enemyControllers; // 관리할 애너미들

    private Transform target;

    // 개별 애너미가 플레이어를 향해 이동하도록 설정
    public void MovePlayer(Transform player)
    {
        target = player;
    }

    // 모든 애너미에게 이동 명령 전달
    public void CommandAllEnemiesToMove(Transform player)
    {
        foreach (var enemy in enemyControllers)
        {
            enemy.MovePlayer(player);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 3f);
        }
    }
}


