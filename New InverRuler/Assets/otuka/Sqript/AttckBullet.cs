using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttckBullet : MonoBehaviour
{
    public static float damage = 5f;  // ’e‚ÌUŒ‚—Í

    void OnTriggerEnter2D(Collider2D other)
    {
        // “G‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
        TEKIHP enemy = other.gameObject.GetComponent<TEKIHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // ’e‚ğÁ‚·
        }
    }
}
