using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackInterval = 3f; // 攻撃の間隔
    private float nextAttackTime;
    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;
    public Transform firePoint;
    public Transform player;
    public int Attack2bulletCount = 5;        // 散弾の数
    public float Attack2spreadAngle = 45f;    // 散弾の広がる角度
    public float Attack2bulletSpeed = 10f;    // 弾のスピード

    void Start()
    {
        nextAttackTime = Time.time + attackInterval;
    }

    void Update()
    {
        // 攻撃のタイミングをチェック
        if (Time.time >= nextAttackTime)
        {
            PerformRandomAttack();
            nextAttackTime = Time.time + attackInterval; // 次の攻撃時間を設定
        }
    }

    void PerformRandomAttack()
    {
        int attackType = Random.Range(1, 4); // 1から3のランダムな攻撃タイプを選択

        switch (attackType)
        {
            case 1:
                AttackType1();
                break;
            case 2:
                AttackType2();
                break;
            case 3:
                AttackType2();
                break;


        }
    }

    //弱攻撃
    void AttackType1()
    {
        // 攻撃1の処理
        Debug.Log("Enemy Attack  1");

        // 弾を発射する処理
        ShootBullet( 10f);

    }


    void ShootBullet( float speed)
    {
        GameObject bullet = Instantiate(Attack1, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = Attack1.GetComponent<Rigidbody2D>();

        Vector3 direction = (player.position - firePoint.position).normalized; // プレイヤーの方向を計算
        rb.velocity = direction * speed; // 指定された速度で発射

    }

    //中攻撃
    void AttackType2()
    {
        Debug.Log("Enemy  Attack  2");

        ShootBullets();
    }

    private void ShootBullets()
    {
        for (int i = 0; i < Attack2bulletCount; i++)
        {
            float angle = i * (360f / Attack2bulletCount) + Time.time * 30f; // 時間に応じて角度を増加
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

            GameObject bullet = Instantiate(Attack2, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * Attack2bulletSpeed;
        }
    }

    void AttackType3()
    {
        Debug.Log("Enemy  Attack  3");

       
    }

}