using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckBullet : MonoBehaviour
{
    public static float damage = 5f;  // ’e‚ÌUŒ‚—Í

    void Awake()
    {
        damage = PlayerPrefs.GetFloat("AttckBulletDamage", 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // “G‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
        USA_normal_HP enemy = other.gameObject.GetComponent<USA_normal_HP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }

        TEKIHP1 enemy1 = other.gameObject.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }

        JapanHP enemy2 = other.gameObject.GetComponent<JapanHP>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }

        HardJapanHP enemy3 = other.gameObject.GetComponent<HardJapanHP>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }

        USA_hardHP enemy4 = other.gameObject.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }

        ROSIA_hard_HP enemy5 = other.gameObject.GetComponent<ROSIA_hard_HP>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }
    }
}