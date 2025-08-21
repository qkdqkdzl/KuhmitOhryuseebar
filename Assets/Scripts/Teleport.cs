using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetPoint;   // �̵��� ��ġ (�� ������Ʈ)
    public float waitTime = 0.5f;   // ����� ��� �ð�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine(other.transform));

        }
    }

    IEnumerator TeleportRoutine(Transform player)   // �̸� �ٲ�
    {
        // ��� (���̵� �ƿ�, ���� �� ���� �ڸ�)
        yield return new WaitForSeconds(waitTime);

        // ��ǥ �̵�
        player.position = targetPoint.position;

        // �̵� ���� �ӵ� �ʱ�ȭ (ƨ�� ����)
        var rb = player.GetComponent<Rigidbody2D>();
        if (rb) rb.velocity = Vector2.zero;
    }
}
