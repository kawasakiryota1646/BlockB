using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendIDOU : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float avoidSpeed = 5f;
    public float returnSpeed = 2f;
    private Vector2 originalPosition;

    void Start()
    {
        // �����ʒu���L��
        originalPosition = transform.position;
    }

    void Update()
    {
        // �e�����m����
        Collider2D[] bullets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        Vector2 avoidDirection = Vector2.zero;
        bool bulletDetected = false;

        foreach (Collider2D bullet in bullets)
        {
            // �e�̃^�O���`�F�b�N
            if (bullet.CompareTag("EnemyBullet"))
            {
                // �e���牓������������v�Z
                Vector2 directionToBullet = transform.position - bullet.transform.position;
                avoidDirection += directionToBullet.normalized;
                bulletDetected = true;
            }
        }

        if (bulletDetected)
        {
            // ����������Ɉړ�
            transform.Translate(avoidDirection.normalized * avoidSpeed * Time.deltaTime);
        }
        else
        {
            // ���̈ʒu�ɖ߂�
            Vector2 directionToOriginal = originalPosition - (Vector2)transform.position;
            if (directionToOriginal.magnitude > 0.1f) // �����̌덷�����e
            {
                transform.Translate(directionToOriginal.normalized * returnSpeed * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // ���m�͈͂����o��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
