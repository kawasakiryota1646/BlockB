using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hard_bear: MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌƒvƒŒƒnƒu
    public float fireRate = 0.1f;   // ’e‚Ì”­ËŠÔŠu
    public int bulletCount = 30;     // •úË‚·‚é’e‚Ì”
    public float spreadAngle = 360f; // •úË‚·‚é’e‚ÌŠp“x”ÍˆÍ
    public float bulletSpeed = 5f;   // ’e‚Ì‘¬“x

    private void Start()
    {
        // ’e–‹‚ğ”­Ë‚·‚éƒRƒ‹[ƒ`ƒ“‚ğŠJn
        StartCoroutine(FireBulletPattern());
    }

    private IEnumerator FireBulletPattern()
    {
        while (true) // –³ŒÀ‚É’e–‹‚ğ”­Ë‚µ‘±‚¯‚é
        {
            // ’e‚ğ•úË‚·‚éŠp“x‚ğŒvZ
            float angleStep = spreadAngle / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = -spreadAngle / 2f + angleStep * i;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;

                // ’e‚ğ¶¬
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                // ’e‚ÌŠÔŠu‚ğ‘Ò‹@
                yield return new WaitForSeconds(fireRate);
            }

            // ˆê“x’e–‹‚ğ‘Å‚¿I‚¦‚½Œã‚É­‚µ‘Ò‚ÂiƒIƒvƒVƒ‡ƒ“j
            yield return new WaitForSeconds(1f);
        }
    }
}
