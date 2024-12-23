using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend_Avoid : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float avoidSpeed = 5f;
    public float returnSpeed = 2f;
    private Vector2 originalPosition;

    void Start()
    {
        // 初期位置を記憶
        originalPosition = transform.position;
    }

    void Update()
    {
        // 弾を検知する
        Collider2D[] bullets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        Vector2 avoidDirection = Vector2.zero;
        bool bulletDetected = false;

        foreach (Collider2D bullet in bullets)
        {
            // 弾のタグをチェック
            if (bullet.CompareTag("EnemyBullet"))
            {
                // 弾から遠ざかる方向を計算
                Vector2 directionToBullet = transform.position - bullet.transform.position;
                avoidDirection += directionToBullet.normalized;
                bulletDetected = true;
            }
        }

        if (bulletDetected)
        {
            // 避ける方向に移動
            transform.Translate(avoidDirection.normalized * avoidSpeed * Time.deltaTime);
        }
        else
        {
            // 元の位置に戻る
            Vector2 directionToOriginal = originalPosition - (Vector2)transform.position;
            if (directionToOriginal.magnitude > 0.1f) // 少しの誤差を許容
            {
                transform.Translate(directionToOriginal.normalized * returnSpeed * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 検知範囲を視覚化
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
