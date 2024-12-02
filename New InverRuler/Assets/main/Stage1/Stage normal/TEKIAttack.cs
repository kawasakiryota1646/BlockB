using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEKIAttack : MonoBehaviour
{
    public GameObject SAKURAPrefab; //弾のプレハブ
    public GameObject HIMAWARIPrefab; //弾のプレハブ
    public GameObject MOMIZIPrefab; //弾のプレハブ
    public GameObject SNOWPrefab; //弾のプレハブ
    public Transform firePoint;     //発射位置のプレハブ
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private JapanHP bossHealth;      //ボスの体力
    public float randomSpeed = 5f;  // 弾の速度
    public int   randomCount = 10;    // 発射する弾の数




    public float rotationSpeed = 50f; // 螺旋の回転速度
    public int bulletCount = 20;      // 発射する弾の数
    public float positionOffset = 1f; // 発射位置のずらし幅

    void Start()
    {
        lastAttackTime = -attackCooldown; // 最初の攻撃がすぐにできるように設定
        bossHealth = GetComponentInParent<JapanHP>(); // 親オブジェクトからBossHealthを取得

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 74)
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 49)
                {
                    AttackPattern2();
                }
                else if(bossHealth.currentHealth > 24)
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
    void AttackPattern1()
    {
        Fire();
    }

    void Fire()
    {
        GameObject bullet = Instantiate(SAKURAPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed; // 下方向に発射
    }

    void AttackPattern2()//ランダム
    {
        int bulletCount = 4; // 弾の数
        float spreadAngle = 50f; // 扇状の角度

        for (int i = 0; i < bulletCount; i++)
        {
            // 弾の角度を計算
            float angle = -spreadAngle / 2 + spreadAngle / (bulletCount - 1) * i;

            // 発射方向を計算
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // 弾を生成
            GameObject bullet = Instantiate(HIMAWARIPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2Dで速度を与える
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern3()
    {
        for (int i = 0; i < randomCount; i++)
        {
            // ランダムな角度を生成 (0度から360度)
            float randomAngle = Random.Range(90f, 270f);

            // 弾を生成
            GameObject bullet = Instantiate(MOMIZIPrefab, transform.position, Quaternion.identity);

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

    void AttackPattern4()
    {
        FireSpiral();
    }

    void FireSpiral()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            // 発射する角度を計算（一定の間隔で角度を増加させる）
            float angle = i * (360f / bulletCount) + rotationSpeed * i * Time.deltaTime;

            // 発射位置を左右にずらす（sinで位置を上下に動かす）
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset; // 位置を左右に動かす

            // ずらした発射位置を設定
            Vector2 adjustedFirePosition = new Vector2(firePoint.position.x + offsetX, firePoint.position.y);

            // 方向を計算
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // 弾を発射
            GameObject bullet = Instantiate(SNOWPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed; // 計算した方向に弾を飛ばす
            }
        }
    }


}


