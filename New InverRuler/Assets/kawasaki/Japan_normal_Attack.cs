using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japan_normal_Attack : MonoBehaviour
{
    //ボスのHPの残りの割合   (定数)
    const int FIRST_STEP = 74;
    const int SECOND_STEP = 49;
    const int THIRD_STEP = 24;

    //弾、発射位置のプレハブ
    public GameObject SakuraPrefab;              //一段階目の弾のプレハブ
    public GameObject SunflowerPrefab;           //二段階目の弾のプレハブ
    public GameObject FallfoliagePrefab;         //三段階目の弾のプレハブ
    public GameObject SnowflakesPrefab;          //四段階目の弾のプレハブ
    public Transform FirePoint;                  //発射位置のプレハブ

    public float AttackCooldown;                 //攻撃のクールダウン
    public float BulletSpeed;                    //全体の弾速

    //二段階目
    public int   Sunflower_bulletCount;          //弾の数
    public float spreadAngle;                    //扇状の角度

    //三段階目
    public float Fallfoliage_randomSpeed;        //弾の速度
    public int   Fallfoliage_randomCount;        //発射する弾の数

    //四段階目
    public float Snowflakes_rotationSpeed;       // 螺旋の回転速度
    public int   Snowflakes_bulletCount;         // 発射する弾の数
    public float positionOffset;                 // 発射位置のずらし幅

    private float lastAttackTime;
    private Japan_normal_HP BossHealth;          //ボスの体力

    void Start()
    {
        lastAttackTime = -AttackCooldown;                   　// 最初の攻撃がすぐにできるように設定
        BossHealth = GetComponentInParent<Japan_normal_HP>(); // 親オブジェクトからBossHealthを取得

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + AttackCooldown)
        {
            if (BossHealth != null)         //HPの量で攻撃パターンが変化する
            {
                if (BossHealth.currentHealth > FIRST_STEP)
                {
                    Spring();
                }
                else if (BossHealth.currentHealth > SECOND_STEP)
                {
                    Summer();
                }
                else if(BossHealth.currentHealth > THIRD_STEP)
                {
                    Fall();
                }
                else
                {
                    Winter();
                }
                lastAttackTime = Time.time; // 最後の攻撃時間を更新
            }
        }
    }


    //一段階目の攻撃
    //下方向に弾を一つ撃つ
    void Spring()
    {
        GameObject bullet = Instantiate(SakuraPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * BulletSpeed; // 下方向に発射

    }

    //二段階目の攻撃
    //下方向に散弾を撃つ
    void Summer()
    {
        for (int i = 0; i < Sunflower_bulletCount; i++)
        {
            // 弾の角度を計算
            float angle = -spreadAngle / 2 + spreadAngle / (Sunflower_bulletCount - 1) * i;

            // 発射方向を計算
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // 弾を生成
            GameObject bullet = Instantiate(SunflowerPrefab, FirePoint.position, Quaternion.identity);

            // Rigidbody2Dで速度を与える
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * BulletSpeed;
            }
        }

    }

    //三段階目の攻撃
    //下方向に扇状に弾を撃つ
    void Fall()
    {
        for (int i = 0; i < Fallfoliage_randomCount; i++)
        {
            // ランダムな角度を生成 (90度から270度)
            float randomAngle = Random.Range(90f, 270f);

            // 弾を生成
            GameObject bullet = Instantiate(FallfoliagePrefab, transform.position, Quaternion.identity);

            // 発射方向を設定
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

            // Rigidbody2D を使用して弾を発射
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * Fallfoliage_randomSpeed;
            }
        }

    }

    //四段階目の攻撃
    //円形状に弾を撃つ
    void Winter()
    {
        for (int i = 0; i < Snowflakes_bulletCount; i++)
        {
            // 発射する角度を計算
            float angle = i * (360f / Snowflakes_bulletCount) + Snowflakes_rotationSpeed * i * Time.deltaTime;

            // 発射位置を左右にずらす
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset;

            // ずらした発射位置を設定
            Vector2 adjustedFirePosition = new Vector2(FirePoint.position.x + offsetX, FirePoint.position.y);

            // 方向を計算
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // 弾を発射
            GameObject bullet = Instantiate(SnowflakesPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // 計算した方向に弾を飛ばす
            if (rb != null)
            {
                rb.velocity = direction * BulletSpeed; 
            }
        }
    }
}


