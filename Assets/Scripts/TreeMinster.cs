//using UnityEngine;

//public class TreeMonster : MonoBehaviour
//{
//    [Header("공격 설정")]
//    [SerializeField] private float attackRange = 2f;   // 공격 범위
//    [SerializeField] private float attackCooldown = 1.5f; // 공격 쿨타임
//    [SerializeField] private int attackDamage = 10;    // 공격 데미지

//    private Transform hero; // Hero Transform
//    private float lastAttackTime = 0f;

//    private void Start()
//    {
//        // Hero 태그로 찾아오기 (Hero 오브젝트에 "Hero" 태그 지정 필요)
//        hero = GameObject.FindGameObjectWithTag("Hero").transform;
//    }

//    private void Update()
//    {
//        if (hero == null) return;

//        // Hero와 TreeMonster 거리 계산
//        float distance = Vector3.Distance(transform.position, hero.position);

//        if (distance <= attackRange)
//        {
//            TryAttackHero();
//        }
//    }

//    private void TryAttackHero()
//    {
//        if (Time.time >= lastAttackTime + attackCooldown)
//        {
//            lastAttackTime = Time.time;

//            // 공격 로직 (애니메이션 트리거 가능)
//            Debug.Log("Tree Monster가 Hero를 공격!");

//            // Hero 체력 감소 (HeroHealth 스크립트 필요)
//            HeroHealth heroHealth = hero.GetComponent<HeroHealth>();
//            if (heroHealth != null)
//            {
//                heroHealth.TakeDamage(attackDamage);
//            }
//        }
//    }
//}
