using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckBullet : MonoBehaviour
{
    public static float damage = 5f;  // �e�̍U����

    void Awake()
    {
        damage = PlayerPrefs.GetFloat("AttckBulletDamage", 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ɓ��������Ƃ��̏���
        USA_normal_HP enemy = other.gameObject.GetComponent<USA_normal_HP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        Russia_normal_HP enemy1 = other.gameObject.GetComponent<Russia_normal_HP>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        Japan_normal_HP enemy2 = other.gameObject.GetComponent<Japan_normal_HP>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        Japan_Hard_Attack enemy3 = other.gameObject.GetComponent<Japan_Hard_Attack>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        USA_hardHP enemy4 = other.gameObject.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }

        Russia_hard_HP enemy5 = other.gameObject.GetComponent<Russia_hard_HP>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }
    }
}