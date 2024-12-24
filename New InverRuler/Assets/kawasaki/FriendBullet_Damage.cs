using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet_Damage : MonoBehaviour
{
    public float speed = 20f;     // ’e‚Ì‘¬“x
    public float lifeTime = 2f;   // ’e‚Ìõ–½
    public static float damage = 1f; // ’e‚Ìƒ_ƒ[ƒW

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed;

        // ’e‚ÌˆĞ—Í‚ğPlayerPrefs‚©‚ç“Ç‚İ‚Ş
        damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f);

        Destroy(gameObject, lifeTime);  // ˆê’èŠÔŒã‚É’e‚ğíœ
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // “G‚É“–‚½‚Á‚½‚©‚Ç‚¤‚©‚ğƒ`ƒFƒbƒN
        USA_normal_HP enemy = collision.GetComponent<USA_normal_HP>();
        if (enemy != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        Russia_normal_HP enemy1 = collision.GetComponent<Russia_normal_HP>();
        if (enemy1 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy1.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }

        Japan_normal_HP enemy2 = collision.GetComponent<Japan_normal_HP>();
        if (enemy2 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy2.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
        Japan_Hard_HP enemy3 = collision.GetComponent<Japan_Hard_HP>();
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

        Russia_hard_HP enemy5 = collision.GetComponent<Russia_hard_HP>();
        if (enemy5 != null)
        {
            // “G‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            enemy5.TakeDamage(damage);
            // ’e‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
    }
}
