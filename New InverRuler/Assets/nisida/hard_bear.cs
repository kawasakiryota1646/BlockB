using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hard_bear: MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public float fireRate = 0.1f;   // 弾の発射間隔
    public int bulletCount = 30;     // 放射する弾の数
    public float spreadAngle = 360f; // 放射する弾の角度範囲
    public float bulletSpeed = 5f;   // 弾の速度

    private void Start()
    {
        // 弾幕を発射するコルーチンを開始
        StartCoroutine(FireBulletPattern());
    }

    private IEnumerator FireBulletPattern()
    {
        while (true) // 無限に弾幕を発射し続ける
        {
            // 弾を放射する角度を計算
            float angleStep = spreadAngle / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = -spreadAngle / 2f + angleStep * i;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;

                // 弾を生成
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                // 弾の間隔を待機
                yield return new WaitForSeconds(fireRate);
            }

            // 一度弾幕を打ち終えた後に少し待つ（オプション）
            yield return new WaitForSeconds(1f);
        }
    }
}
