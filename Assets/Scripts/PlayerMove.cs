using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 5f;

    [Header("점프")]
    public float jump = 10f;

    [Header("바닥 체크")]
    public Transform ground;
    public float groundCheckRadius = 0.1f;
    public LayerMask layerMask;

    Rigidbody2D rb;
    SpriteRenderer sr;
    bool isGrounded;
    int jumpsUsed = 0;                // 이번 착지 전까지 사용한 점프 횟수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        // 바닥체크
        isGrounded = Physics2D.OverlapCircle(ground.position, groundCheckRadius, layerMask);
        if (isGrounded) jumpsUsed = 0;

        // 움직이는 키 값
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
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Y속도 초기화 (중복 점프시 일관성 유지)
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    
}
