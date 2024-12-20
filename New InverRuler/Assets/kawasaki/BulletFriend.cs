using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // 弾の速度
    public float lifeTime = 2f;   // 弾の寿命
    public static float damage = 1f; // 弾のダメージ

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        // 弾の威力をPlayerPrefsから読み込む
        damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f);

        Destroy(gameObject, lifeTime);  // 一定時間後に弾を削除
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 敵に当たったかどうかをチェック
        TEKIHP enemy = collision.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            // 敵にダメージを与える
            enemy.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }

        TEKIHP1 enemy1 = collision.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            // 敵にダメージを与える
            enemy1.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }

        JapanHP enemy2 = collision.GetComponent<JapanHP>();
        if (enemy2 != null)
        {
            // 敵にダメージを与える
            enemy2.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }
        HardJapanHP enemy3 = collision.GetComponent<HardJapanHP>();
        if (enemy3 != null)
        {
            // 敵にダメージを与える
            enemy3.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }

        USA_hardHP enemy4 = collision.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            // 敵にダメージを与える
            enemy4.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }

        ROSIA_hard_HP enemy5 = collision.GetComponent<ROSIA_hard_HP>();
        if (enemy5 != null)
        {
            // 敵にダメージを与える
            enemy5.TakeDamage(damage);
            // 弾を破壊する
            Destroy(gameObject);
        }
    }
}
