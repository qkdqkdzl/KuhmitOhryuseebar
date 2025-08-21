using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�̵�")]
    public float moveSpeed = 5f;

    [Header("����")]
    public float jump = 10f;

    [Header("�ٴ� üũ")]
    public Transform ground;
    public float groundCheckRadius = 0.1f;
    public LayerMask layerMask;

    Rigidbody2D rb;
    SpriteRenderer sr;
    bool isGrounded;
    int jumpsUsed = 0;                // �̹� ���� ������ ����� ���� Ƚ��

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        // �ٴ�üũ
        isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, layerMask);
        if (isGrounded) jumpsUsed = 0;

        // �����̴� Ű ��
        float h = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            h = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            h = -1f;
        }
        

        //if (Input.GetKey(KeyCode.RightArrow))
        //    h = 1f;
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //    h = -1f;


        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
        if (h != 0) sr.flipX = h < 0;

        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Y�ӵ� �ʱ�ȭ (�ߺ� ������ �ϰ��� ����)
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    
}
