using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFriend : MonoBehaviour
{
    public float speed = 20f;     // ’e‚Ì‘¬“x
    public float lifeTime = 2f;   // ’e‚Ìõ–½
    public int damage = 1;        //’e‚Ìƒ_ƒ[ƒW

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);  // ˆê’èŠÔŒã‚É’e‚ğíœ
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // “G‚É“–‚½‚Á‚½‚©‚Ç‚¤‚©‚ğƒ`ƒFƒbƒN
        TEKIHP enemy = collision.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        TEKIHP1 enemy1 = collision.GetComponent<TEKIHP1>();
        if (enemy1 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy1.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        JapanHP enemy2 = collision.GetComponent<JapanHP>();
        if (enemy2 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy2.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
        HardJapanHP enemy3 = collision.GetComponent<HardJapanHP>();
        if (enemy3 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy3.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        USA_hardHP enemy4 = collision.GetComponent<USA_hardHP>();
        if (enemy4 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy4.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        ROSIA_hard_HP enemy5 = collision.GetComponent<ROSIA_hard_HP>();
        if (enemy5 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy5.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
    }
}

