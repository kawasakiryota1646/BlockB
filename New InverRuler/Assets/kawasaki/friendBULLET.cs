using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendBULLET : MonoBehaviour
{
    public static float damage = 0f;  // 弾の攻撃力

    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たったときの処理
        TEKIHP enemy = other.gameObject.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
        TEKIHP1 enemy1= other.gameObject.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
        JapanHP enemy2 = other.gameObject.GetComponent<JapanHP>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }

        HardJapanHP enemy3 = other.gameObject.GetComponent<HardJapanHP>();
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

        ROSIA_hard_HP enemy5 = other.gameObject.GetComponent<ROSIA_hard_HP>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(damage);
            Destroy(gameObject); // 弾を消す
        }
    }

}
