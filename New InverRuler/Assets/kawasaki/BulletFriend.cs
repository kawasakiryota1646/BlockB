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
    }
}
