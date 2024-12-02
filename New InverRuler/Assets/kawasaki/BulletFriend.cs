using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // �e�̑��x
    public float lifeTime = 2f;   // �e�̎���
    public int damage = 1;        //�e�̃_���[�W

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);  // ��莞�Ԍ�ɒe���폜
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �G�ɓ����������ǂ������`�F�b�N
        TEKIHP enemy = collision.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        TEKIHP1 enemy1 = collision.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy1.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        JapanHP enemy2 = collision.GetComponent<JapanHP>();
        if (enemy2 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy2.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }
        HardJapanHP enemy3 = collision.GetComponent<HardJapanHP>();
        if (enemy3 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy3.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        USA_hardHP enemy4 = collision.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy4.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        ROSIA_hard_HP enemy5 = collision.GetComponent<ROSIA_hard_HP>();
        if (enemy5 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy5.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }
    }
}

