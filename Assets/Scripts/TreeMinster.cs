using UnityEngine;

public class TreeMonster : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Herohp herohp = other.GetComponent<Herohp>();
        if (herohp != null)
        {
            herohp.TakeDamage(damage);
            Debug.Log("���Ϳ� ��Ƽ� ü�� ����!");
        }
    }
}
