using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet_Damage : MonoBehaviour
{
    public float speed = 20f;     // �e�̑��x
    public float lifeTime = 2f;   // �e�̎���
    public static float damage = 1f; // �e�̃_���[�W

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        // �e�̈З͂�PlayerPrefs����ǂݍ���
        damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f);

        Destroy(gameObject, lifeTime);  // ��莞�Ԍ�ɒe���폜
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �G�ɓ����������ǂ������`�F�b�N
        USA_normal_HP enemy = collision.GetComponent<USA_normal_HP>();
        if (enemy != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        Russia_normal_HP enemy1 = collision.GetComponent<Russia_normal_HP>();
        if (enemy1 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy1.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }

        Japan_normal_HP enemy2 = collision.GetComponent<Japan_normal_HP>();
        if (enemy2 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy2.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }
        Japan_Hard_Attack enemy3 = collision.GetComponent<Japan_Hard_Attack>();
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

        Russia_hard_HP enemy5 = collision.GetComponent<Russia_hard_HP>();
        if (enemy5 != null)
        {
            // �G�Ƀ_���[�W��^����
            enemy5.TakeDamage(damage);
            // �e��j�󂷂�
            Destroy(gameObject);
        }
    }
}
