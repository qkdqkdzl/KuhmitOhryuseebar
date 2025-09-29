using System.Linq;
using UnityEngine;

public enum PlayerState
{
    Idle, Attack, Attack2, Jump
    
}

public class PlayerStateMachine : MonoBehaviour
{
    [Header("------애니메이션용 에니메이터------")]
    [SerializeField] private Animator animator;

    public PlayerState CurrentState { get; private set; } = PlayerState.Idle;

    // 캐시: Animator에 실제 존재하는 Trigger 파라미터 이름들
    string[] _triggerNames;

    void Awake()
    {
        if (!animator) animator = GetComponentInChildren<Animator>();
        CacheTriggerNames();

        // 초기 상태를 '독점 트리거'로 발동
        FireExclusiveTrigger(CurrentState.ToString());
    }

    void CacheTriggerNames()
    {
        if (!animator || animator.runtimeAnimatorController == null) { _triggerNames = System.Array.Empty<string>(); return; }
        _triggerNames = animator.parameters
            .Where(p => p.type == AnimatorControllerParameterType.Trigger)
            .Select(p => p.name)
            .ToArray();
    }

    /// 상태 전환: 모든 다른 트리거를 먼저 Reset하고, 새 트리거만 Set
    public void SetState(PlayerState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
        FireExclusiveTrigger(newState.ToString());
    }

    void FireExclusiveTrigger(string triggerName)
    {
        if (!animator || animator.runtimeAnimatorController == null) return;
        if (_triggerNames == null || _triggerNames.Length == 0) CacheTriggerNames();

        // 다른 트리거 전부 해제
        for (int i = 0; i < _triggerNames.Length; i++)
        {
            var t = _triggerNames[i];
            if (!string.Equals(t, triggerName, System.StringComparison.Ordinal))
            {
                animator.ResetTrigger(t);
            }
        }
        animator.SetTrigger(triggerName);
    }
}