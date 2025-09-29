using UnityEngine;

public class EnemyAiBase : MonoBehaviour
{
    [Header("---------- 공격 대상 ----------")]
    public Transform player;            

    [Header("---------- 감지 범위 ----------")]
    public float detectRange = 10f;     // 적이 플레이어를 감지하는 거리
    public float attackRange = 2f;      // 공격이 가능한 거리

    [Header("---------- 이속 ----------")]
    public float moveSpeed = 3f;        

    [Header("---------- 공격 속도 ----------")]
    public float attackCooldown = 1f;   
    private float lastAttackTime;


    private Rigidbody2D rb;
    private SpriteRenderer sr;   // ← SpriteRenderer 추가
    private Animator animator;   // ← Animator 추가
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 적 본체에 Rigidbody2D가 있어야 작동
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();  // Animator 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!player) return; // 플레이어 없으면 실행 안 함

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= attackRange)
        {
            // 공격 범위 안이면 공격
            Attack();
        }
        else if (dist <= detectRange)
        {
            // 탐지 범위 안이면 플레이어 쫓아감
            MoveTowardsPlayer();
        }
        else
        {
            // 탐지 범위 밖이면 대기
            Idle();
        }
    }

    /// <summary>
    /// 플레이어 방향으로 이동
    /// </summary>
    void MoveTowardsPlayer()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * moveSpeed;

        // 플레이어 위치 기준으로 flipX 설정
        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true; // 플레이어가 왼쪽에 있으면 뒤집기
        }
        else
        {
            spriteRenderer.flipX = false; // 플레이어가 오른쪽에 있으면 원래대로
        }
    }

    /// <summary>
    /// 공격 로직 (근접/원거리)
    /// </summary>
    void Attack()
    {
        // 공격 시 멈춤
        rb.velocity = Vector2.zero;

        // 애니메이션 실행
        if (animator != null)
        {
            animator.SetTrigger("Attack");  // Animator 파라미터 "Attack" 실행
        }
    }

    /// <summary>
    /// 대기 상태 (정지)
    /// </summary>
    void Idle()
    {
        rb.velocity = Vector2.zero;
    }
}
