using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 여러 애너미를 관리해주는 스크립트
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public List<EnemyController> enemies;

    public void CommandEnemiesToMove(Transform playerTransform)
    {
        foreach (var enemy in enemies)
        {
            enemy.MoveToPlayer(playerTransform);
        }
    }
}

