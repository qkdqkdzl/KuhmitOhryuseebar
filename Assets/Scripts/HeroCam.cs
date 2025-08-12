using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCam : MonoBehaviour
{
    [Header("---------- Target ----------")]
    public Transform target;          // 따라갈 히어로 Transform

    [Header("----------- Follow ----------")]
    public Vector2 offset = new Vector2(0f, 0.5f); // 화면에서 살짝 위로
    [Range(0.01f, 0.5f)]
    public float smoothTime = 0.15f;  // 작을수록 타이트, 클수록 부드러움

    [Header("--------- Bounds ----------")]
    public bool useBounds = false;
    public Vector2 minBounds;         // (xMin, yMin)
    public Vector2 maxBounds;         // (xMax, yMax)

    Vector3 _velocity;                // SmoothDamp용 내부 속도

    void LateUpdate()
    {
        if (!target) return;

        // 목표 위치(타겟 + 오프셋), z는 카메라 z 유지(-10 권장)
        Vector3 desired = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z
        );

        // 부드럽게 이동
        Vector3 nextPos = Vector3.SmoothDamp(transform.position, desired, ref _velocity, smoothTime);

        // 경계 제한
        if (useBounds)
        {
            nextPos.x = Mathf.Clamp(nextPos.x, minBounds.x, maxBounds.x);
            nextPos.y = Mathf.Clamp(nextPos.y, minBounds.y, maxBounds.y);
        }

        transform.position = nextPos;
    }
}
