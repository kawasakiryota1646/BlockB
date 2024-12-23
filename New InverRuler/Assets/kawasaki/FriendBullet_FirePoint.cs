using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet_FirePoint : MonoBehaviour
{
    public GameObject bulletPrefab;         // ”­Ë‚·‚é’e‚ÌƒvƒŒƒnƒu
    public Transform firePoint;             // ’e‚ğ”­Ë‚·‚éˆÊ’u
    public float fireRate = 0.5f;           // ”­ËŠÔŠui•bj
    private float nextFireTime = 0f;        // Ÿ‚É’e‚ğ”­Ë‚Å‚«‚éŠÔ
    public float damage = 10f;              // ’e‚ÌUŒ‚—Í

    void Update()
    {
        // Œ»İ‚ÌŠÔ‚ªŸ‚Ì”­ËŠÔ‚ğ’´‚¦‚Ä‚¢‚½‚ç”­Ë
        if (Time.time >= nextFireTime)
        {
            Shoot();  // ’e‚ğ”­Ë
            nextFireTime = Time.time + fireRate;  // Ÿ‚Ì”­ËŠÔ‚ğİ’è
        }
    }

    void Shoot()
    {
        // ’e‚ğ¶¬‚µAfirePoint‚ÌˆÊ’u‚ÆŒü‚«‚Å”­Ë
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
