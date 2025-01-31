using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet_Judgment : MonoBehaviour
{
    public static float damage = 0f;  // 弾の攻撃力

    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たったときの処理
        USA_normal_HP enemy = other.gameObject.GetComponent<USA_normal_HP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
        Russia_normal_HP enemy1 = other.gameObject.GetComponent<Russia_normal_HP>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
        Japan_normal_HP enemy2 = other.gameObject.GetComponent<Japan_normal_HP>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }

        Japan_Hard_HP enemy3 = other.gameObject.GetComponent<Japan_Hard_HP>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }

        USA_hardHP enemy4 = other.gameObject.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }

        Russia_hard_HP enemy5 = other.gameObject.GetComponent<Russia_hard_HP>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
    }

}
