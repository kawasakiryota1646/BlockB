using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class USA_normal_Attack : MonoBehaviour
{
    public GameObject UKIPrefab; //弾のプレハブ
    public GameObject POTATOPrefab; //弾のプレハブ
    public GameObject hamburgerPrefab; //弾のプレハブ
    public GameObject SNOWPrefab; //弾のプレハブ
    public Transform firePoint;     //発射位置のプレハブ
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    public float fireInterval = 5f; // 発射間隔

    private float lastAttackTime;
    private USA_normal_HP bossHealth;      //ボスの体力


    public float POTATOSpeed = 5f;

    public float shootInterval = 1.5f; // 弾を撃つ間隔
    public int bulletCount = 12;     // 発射する弾の数
    public float burgerSpeed = 5f;   // 弾の速度
    public float angleRange = 180f; // 放射する範囲


    public float spawnInterval = 0.2f; // 弾を生成する間隔
    public int bulletsPerWave = 10;   // 1回のウェーブで降らせる弾の数
    public float rainbulletSpeed = 5f;    // 弾の落下速度
    public float spawnAreaWidth = 10f; // 弾が生成される範囲の幅



    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = -attackCooldown; // 最初の攻撃がすぐにできるように設定
        bossHealth = GetComponentInParent<USA_normal_HP>(); // 親オブジェクトからBossHealthを取得

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 225)
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 150)
                {
                    AttackPattern2();
                }
                else if (bossHealth.currentHealth > 75)
                {
                    AttackPattern3();
                }
                else
                {
                    AttackPattern4();
                }

                lastAttackTime = Time.time; // 最後の攻撃時間を更新
            }
        }

    }

    void AttackPattern1()//三方向
    {
        int bulletCount = 3; // 弾の数
        float spreadAngle = 50f; // 扇状の角度

        for (int i = 0; i < bulletCount; i++)
        {
            // 弾の角度を計算
            float angle = -spreadAngle / 2 + spreadAngle / (bulletCount - 1) * i;

            // 発射方向を計算
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // 弾を生成
            GameObject bullet = Instantiate(UKIPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2Dで速度を与える
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern2()//直線
    {
        POTATOFire(); // 弾を発射
    }

    void POTATOFire()
    {
        // 弾を生成
        GameObject bullet = Instantiate(POTATOPrefab, firePoint.position, Quaternion.identity);

        // 弾を下方向に飛ばす
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * POTATOSpeed; // 常に下方向に発射
        }

        // 弾の自動消滅（例: 5秒後に削除）
        Destroy(bullet, 5f);
    }

    void AttackPattern3()//6方向
    {

        RadialShot();

    }

    void RadialShot()
    {
        float startAngle = -angleRange / 2;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleRange / (bulletCount - 1)) * i;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            GameObject bullet = Instantiate(hamburgerPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }

    void AttackPattern4()
    {
        SpawnBulletWave();
    }

    void SpawnBulletWave()
    {
        for (int i = 0; i < bulletsPerWave; i++)
        {
            // ランダムなX座標を計算
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

            // 弾を生成
            GameObject bullet = Instantiate(SNOWPrefab, spawnPosition, Quaternion.identity);

            // 弾に速度を与える
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * rainbulletSpeed;
            }
        }
    }

}
