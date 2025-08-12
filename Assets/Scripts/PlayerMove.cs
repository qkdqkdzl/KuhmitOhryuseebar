using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�̵�")]
    public float moveSpeed = 5f;

    [Header("����")]
    public float jumpForce = 10f;

    [Header("�ٴ�")]
    public Transform ground;   // �߹� ��ġ
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
        // �ٴ� üũ
        isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, layerMask);

        // Ű �Է� (A, D)
        float h = 0f;
        if (Input.GetKey(KeyCode.A)) h = -1f;
        else if (Input.GetKey(KeyCode.D)) h = 1f;

        // �̵�
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // �¿� ����
        if (h > 0) spriteRenderer.flipX = false;
        else if (h < 0) spriteRenderer.flipX = true;

        // ���� (�����̽���)
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
