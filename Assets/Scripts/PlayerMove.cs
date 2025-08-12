using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 5f;

    [Header("점프")]
    public float jumpForce = 10f;

    [Header("바닥")]
    public Transform ground;   // 발밑 위치
    public float groundCheckRadius = 0.1f;
    public LayerMask layerMask;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 바닥 체크
        isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, layerMask);

        // 키 입력 (A, D)
        float h = 0f;
        if (Input.GetKey(KeyCode.A)) h = -1f;
        else if (Input.GetKey(KeyCode.D)) h = 1f;

        // 이동
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // 좌우 반전
        if (h > 0) spriteRenderer.flipX = false;
        else if (h < 0) spriteRenderer.flipX = true;

        // 점프 (스페이스바)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (ground == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ground.position, groundCheckRadius);
    }
}
