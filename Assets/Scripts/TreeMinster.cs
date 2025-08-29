//using UnityEngine;

//public class TreeMonster : MonoBehaviour
//{
//    [Header("���� ����")]
//    [SerializeField] private float attackRange = 2f;   // ���� ����
//    [SerializeField] private float attackCooldown = 1.5f; // ���� ��Ÿ��
//    [SerializeField] private int attackDamage = 10;    // ���� ������

//    private Transform hero; // Hero Transform
//    private float lastAttackTime = 0f;

//    private void Start()
//    {
//        // Hero �±׷� ã�ƿ��� (Hero ������Ʈ�� "Hero" �±� ���� �ʿ�)
//        hero = GameObject.FindGameObjectWithTag("Hero").transform;
//    }

//    private void Update()
//    {
//        if (hero == null) return;

//        // Hero�� TreeMonster �Ÿ� ���
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

//            // ���� ���� (�ִϸ��̼� Ʈ���� ����)
//            Debug.Log("Tree Monster�� Hero�� ����!");

//            // Hero ü�� ���� (HeroHealth ��ũ��Ʈ �ʿ�)
//            HeroHealth heroHealth = hero.GetComponent<HeroHealth>();
//            if (heroHealth != null)
//            {
//                heroHealth.TakeDamage(attackDamage);
//            }
//        }
//    }
//}
