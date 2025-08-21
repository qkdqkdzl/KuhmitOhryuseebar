using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetPoint;   // 이동할 위치 (빈 오브젝트)
    public float waitTime = 0.5f;   // 연출용 대기 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine(other.transform));

        }
    }

    IEnumerator TeleportRoutine(Transform player)   // 이름 바꿈
    {
        // 대기 (페이드 아웃, 사운드 등 넣을 자리)
        yield return new WaitForSeconds(waitTime);

        // 좌표 이동
        player.position = targetPoint.position;

        // 이동 직후 속도 초기화 (튕김 방지)
        var rb = player.GetComponent<Rigidbody2D>();
        if (rb) rb.velocity = Vector2.zero;
    }
}
