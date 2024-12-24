using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japan_Hard_Attack : MonoBehaviour
{
    public GameObject SakuraPrefab;      //弾のプレハブ
    public GameObject SunflowerPrefab;   //弾のプレハブ
    public GameObject FallfoliagePrefab; //弾のプレハブ
    public GameObject SnowflakesPrefab;  //弾のプレハブ
    public Transform firePoint;          //発射位置のプレハブ
    public float bulletSpeed = 5f;       //桜の弾速
    public float attackCooldown = 1.0f;  //桜の弾の間隔
    public int Sunflower_bulletCount = 4;// 弾の数
    public float spreadAngle = 50f;      // 扇状の角度
    private float lastAttackTime;
    private Japan_Hard_HP bossHealth;    //ボスの体力
    public float randomSpeed = 5f;       // 紅葉の弾の速度
    public int randomCount = 10;         // 紅葉の発射する弾の数
    public int Snowflakes_bulletCount = 20;// 雪の結晶の弾の数
    public float rotationSpeed = 50f; // 螺旋の回転速度
    public float positionOffset = 1f; // 発射位置のずらし幅


    void Start()
    {
        lastAttackTime = -attackCooldown; // 最初の攻撃がすぐにできるように設定
        bossHealth = GetComponentInParent<Japan_Hard_HP>(); // 親オブジェクトからBossHealthを取得

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 225)//ボスのHPが225以上なら第一形態
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 150)//ボスのHPが150以上なら第二形態
                {
                    AttackPattern2();
                }
                else if (bossHealth.currentHealth > 75)//ボスのHPが75以上なら第三形態
                {
                    AttackPattern3();
                }
                else//ボスのHPが75以下なら第四形態
                {
                    AttackPattern4();
                }
                lastAttackTime = Time.time; // 最後の攻撃時間を更新
            }
        }
    }
    void AttackPattern1()//真っすぐ弾を撃つ
    {
        Sakura();
    }

    void Sakura()
    {
        GameObject bullet = Instantiate(SakuraPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed; // 下方向に発射
    }

    void AttackPattern2()//散弾
    {

        for (int i = 0; i < Sunflower_bulletCount; i++)
        {
            // 弾の角度を計算
            float angle = -spreadAngle / 2 + spreadAngle / (Sunflower_bulletCount - 1) * i;

            // 発射方向を計算
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // 弾を生成
            GameObject bullet = Instantiate(SunflowerPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2Dで速度を与える
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern3()//ランダム
    {
        for (int i = 0; i < randomCount; i++)
        {
            // ランダムな角度を生成 (0度から360度)
            float randomAngle = Random.Range(90f, 270f);

            // 弾を生成
            GameObject bullet = Instantiate(FallfoliagePrefab, transform.position, Quaternion.identity);

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

    void AttackPattern4()//円形に攻撃
    {
        Snowflakes();
    }

    void Snowflakes()
    {
        for (int i = 0; i < Snowflakes_bulletCount; i++)
        {
            // 発射する角度を計算（一定の間隔で角度を増加させる）
            float angle = i * (360f / Snowflakes_bulletCount) + rotationSpeed * i * Time.deltaTime;

            // 発射位置を左右にずらす（sinで位置を上下に動かす）
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset; // 位置を左右に動かす

            // ずらした発射位置を設定
            Vector2 adjustedFirePosition = new Vector2(firePoint.position.x + offsetX, firePoint.position.y);

            // 方向を計算
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // 弾を発射
            GameObject bullet = Instantiate(SnowflakesPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed; // 計算した方向に弾を飛ばす
            }
        }
    }

}
