using UnityEngine;

public class EnemyAiBase : MonoBehaviour
{
    [Header("---------- 공격 대상 ----------")]
    public Transform player; // 플레이어의 Transform을 받아옴 (Inspector에서 연결 필요)

    [Header("---------- 감지 범위 ----------")]
    public float detectRange = 10f; // 플레이어를 감지하는 거리
    public float attackRange = 2f;  // 공격 가능한 거리 (현재는 사용되지 않음)

    [Header("---------- 이동 속도 ----------")]
    public float moveSpeed = 3f; // 적의 이동 속도

    [Header("---------- 공격 쿨타임 ----------")]
    public float attackCooldown = 1f; // 공격 간격
    private float lastAttackTime;     // 마지막 공격 시간 기록용

    // 내부 컴포넌트 참조
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // 플레이어의 상태 머신 (공격 애니메이션을 실행하기 위해 필요)
    private PlayerStateMachine PSM;

    void Start()
    {
        // 적 본체에 필요한 컴포넌트들을 가져옴
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // 플레이어가 연결되어 있다면 상태 머신을 자식 포함해서 검색
        if (player != null)
        {
            PSM = player.GetComponent<PlayerStateMachine>();
            if (PSM == null)
            {
                // 자식 오브젝트에 붙어 있을 경우도 고려
                PSM = player.GetComponentInChildren<PlayerStateMachine>();
            }
        }

        // 디버깅용 로그: PSM이 null이면 경고 출력
        if (PSM == null)
        {
            Debug.LogWarning("PlayerStateMachine 컴포넌트를 플레이어에서 찾을 수 없습니다. 공격 애니메이션이 실행되지 않을 수 있습니다.");
        }
    }

    void Update()
    {
        // 플레이어가 없으면 아무 것도 하지 않음
        if (!player) return;

        // 플레이어와의 거리 계산
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectRange)
        {
            // 탐지 범위 안에 있으면 이동 및 공격
            MoveTowardsPlayer();

            // 공격 쿨타임 체크
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    /// <summary>
    /// 플레이어 방향으로 이동
    /// </summary>
    void MoveTowardsPlayer()
    {
        // 방향 벡터 계산 및 이동
        Vector2 dir = (player.position - transform.position).normalized;
        rb.velocity = dir * moveSpeed;

        // 플레이어 위치 기준으로 sprite 방향 전환
        spriteRenderer.flipX = player.position.x < transform.position.x;
    }

    /// <summary>
    /// 공격 로직
    /// </summary>
    void Attack()
    {
        // 공격 시 멈춤
        rb.velocity = Vector2.zero;

        // 플레이어의 상태 머신이 존재하면 공격 애니메이션 실행
        if (PSM != null)
        {
            PSM.SetState(PlayerState.Attack);
        }
        else
        {
            Debug.LogWarning("공격 시도 중 PSM이 null입니다. 애니메이션 실행 실패.");
        }
    }
}
