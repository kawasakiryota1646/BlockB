using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendBULLET : MonoBehaviour
{
    public float damage = 10f;  // �e�̍U����

    void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ɓ��������Ƃ��̏���
        TEKIHP enemy = other.gameObject.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // �e������
        }
    }

}
