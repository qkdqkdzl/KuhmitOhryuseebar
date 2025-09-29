using UnityEngine;

public class KnightManager : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private Rigidbody2D rb;

    [Header("공격 애니메이션 지속 시간")]
    public float attackDuration = 0.5f;
    private float attackTimer = 0f;
    private bool isAttacking = false;

    [Header("점프 설정")]
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        rb = GetComponent<Rigidbody2D>();

        if (stateMachine == null)
            Debug.LogWarning("PlayerStateMachine 컴포넌트를 찾을 수 없습니다.");

        if (rb == null)
            Debug.LogWarning("Rigidbody2D 컴포넌트를 찾을 수 없습니다.");
    }

    void Update()
    {
        if (stateMachine == null || rb == null) return;

        // 공격 입력
        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stateMachine.SetState(PlayerState.Attack);
                StartAttackTimer();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                stateMachine.SetState(PlayerState.Attack2);
                StartAttackTimer();
            }
        }

        // 공격 후 Idle 복귀
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                stateMachine.SetState(PlayerState.Idle);
                isAttacking = false;
            }
        }

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void StartAttackTimer()
    {
        isAttacking = true;
        attackTimer = attackDuration;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    } 
}
