using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCam : MonoBehaviour
{
    [Header("---------- Target ----------")]
    public Transform target;          // ���� ����� Transform

    [Header("----------- Follow ----------")]
    public Vector2 offset = new Vector2(0f, 0.5f); // ȭ�鿡�� ��¦ ����
    [Range(0.01f, 0.5f)]
    public float smoothTime = 0.15f;  // �������� Ÿ��Ʈ, Ŭ���� �ε巯��

    [Header("--------- Bounds ----------")]
    public bool useBounds = false;
    public Vector2 minBounds;         // (xMin, yMin)
    public Vector2 maxBounds;         // (xMax, yMax)

    Vector3 _velocity;                // SmoothDamp�� ���� �ӵ�

    void LateUpdate()
    {
        if (!target) return;

        // ��ǥ ��ġ(Ÿ�� + ������), z�� ī�޶� z ����(-10 ����)
        Vector3 desired = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z
        );

        // �ε巴�� �̵�
        Vector3 nextPos = Vector3.SmoothDamp(transform.position, desired, ref _velocity, smoothTime);

        // ��� ����
        if (useBounds)
        {
            nextPos.x = Mathf.Clamp(nextPos.x, minBounds.x, maxBounds.x);
            nextPos.y = Mathf.Clamp(nextPos.y, minBounds.y, maxBounds.y);
        }

        transform.position = nextPos;
    }
}
