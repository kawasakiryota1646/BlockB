using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEKIAttack : MonoBehaviour
{
    public GameObject bulletPrefab; //弾のプレハブ
    public GameObject laserPrefab;
    public Transform firePoint;     //発射位置のプレハブ
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private TEKIHP bossHealth;      //ボスの体力
    private float spiralAngle = 0f;

    public float randomSpeed = 5f;  // 弾の速度
    public int   randomCount = 10;    // 発射する弾の数


    void Start()
    {
        lastAttackTime = -attackCooldown; // 最初の攻撃がすぐにできるように設定
        bossHealth = GetComponentInParent<TEKIHP>(); // 親オブジェクトからBossHealthを取得

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 50)
                {
                    AttackPattern1(8);
                }
                else if (bossHealth.currentHealth > 20)
                {
                    AttackPattern2();
                }
                else
                {
                    AttackPattern3();
                }
                lastAttackTime = Time.time; // 最後の攻撃時間を更新
            }
        }
    }
    void AttackPattern1(int bulletCount)//円形
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
            FireBullet(direction);
            angle += angleStep;
        }


    }

    void FireBullet(Vector3 direction)//ホーミング
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void AttackPattern2()//ランダム
    {
        for (int i = 0; i < randomCount; i++)
        {
            // ランダムな角度を生成 (0度から360度)
            float randomAngle = Random.Range(0f, 360f);

            // 弾を生成
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 発射方向を設定
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

            // Rigidbody2D を使用して弾を発射
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * randomSpeed;
            }
        }

    }

    void AttackPattern3()
    {
       

    }



}


