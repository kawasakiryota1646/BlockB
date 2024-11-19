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
    }
}
