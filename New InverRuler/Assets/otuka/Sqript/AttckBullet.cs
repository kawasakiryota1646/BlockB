using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckBullet : MonoBehaviour
{
    public static float damage = 5f;  // �e�̍U����

    void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ɓ��������Ƃ��̏���
        TEKIHP enemy = other.gameObject.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        TEKIHP1 enemy1 = other.gameObject.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }


    }
}
