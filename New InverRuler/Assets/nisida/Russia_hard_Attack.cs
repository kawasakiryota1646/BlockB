using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Russia_hard_Attack : MonoBehaviour
{
    public GameObject onePrefab; //弾のプレハブ
    public GameObject twoPrefab; //弾のプレハブ
    public GameObject threePrefab; //弾のプレハブ
    public GameObject forePrefab; //弾のプレハブ
    public Transform firePoint;     //発射位置のプレハブ
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private Russia_hard_HP bossHealth;      //ボスの体力

    public float fireRate = 1f;      // 発射間隔
    public float bulletSpeed = 5f;   // 弾の速度
    private float nextFireTime = 0f; // 次に弾を発射する時間

    public int randomCount = 10;
    public float randomSpeed = 5f;

    public float speed = 10000f; // ブーメランの移動速度
    public float returnSpeed = 5f; // 戻る時のスピード
    public float maxDistance = 20f; // ブーメランが進む最大距離
    private Vector3 startPosition; // 発射位置
    private bool isReturning = false; // 戻り中かどうか
    private Transform player; // プレイヤーの位置

    public float snowspeed = 5f; // 玉の移動速度
    public float growthRate = 0.1f; // 玉が成長する速さ
    public float maxSize = 100f; // 玉の最大サイズ
    private Vector3 initialScale; // 初期のスケール（サイズ）




    void Start()
    {
        lastAttackTime = -attackCooldown; // 最初の攻撃がすぐにできるように設定
        bossHealth = GetComponentInParent<Russia_hard_HP>(); // 親オブジェクトからBossHealthを取得

        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // プレイヤーを検索

        initialScale = transform.localScale; // 玉の初期スケールを保存


    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 1500)
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 1000)
                {
                    AttackPattern2();
                }
                else if (bossHealth.currentHealth > 500)
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

        FireBullet();
    }

    void FireBullet()
    {
        // 弾を生成
        GameObject bullet = Instantiate(onePrefab, transform.position, Quaternion.identity);

        // 弾に速度を与えて下方向に移動させる
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * bulletSpeed; // 弾を下方向に移動
        }
    }

    void AttackPattern2()
    {
        GameObject bullet = Instantiate(twoPrefab, transform.position, Quaternion.identity);

        // ブーメランが戻っている場合は、プレイヤー位置に向かって戻る
        if (isReturning)
        {
            ReturnToPlayer();
        }
        else
        {
            // ブーメランを前進させる
            MoveForward(bullet);
        }

    }

    void MoveForward(GameObject bullet)
    {
        // ブーメランが最大距離に到達したら戻る
        float distanceTravelled = Vector3.Distance(player.position, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            isReturning = true;
        }

        // ブーメランがプレイヤーに向かって飛んでいる場合
        Vector3 direction = player.position - transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed * Time.deltaTime;
    }

    void ReturnToPlayer()
    {


        // プレイヤーに向かって戻る
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * returnSpeed * Time.deltaTime;

        // プレイヤーに到達したら、攻撃が完了したので自分自身を削除
        if (Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void AttackPattern3()
    {

        GameObject bullet;
        // 玉が下に移動する
        bullet = MoveDown();

        // 玉を大きくする
        Grow(bullet);

    }

    GameObject MoveDown()
    {
        GameObject bullet = Instantiate(threePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * snowspeed; // 弾を下方向に移動

        }
        return bullet;
    }

    void Grow(GameObject bullet)
    {
        // 玉の現在のスケールを取得
        Vector3 currentScale = bullet.transform.localScale;
        Vector3 bulletScale;

        bulletScale.x = currentScale.x + growthRate * bullet.transform.position.y;
        bulletScale.y = currentScale.y + growthRate * bullet.transform.position.y;
        bulletScale.z = currentScale.z;

        // 玉が最大サイズに達していない場合、成長させる
        if (currentScale.x < maxSize && currentScale.y < maxSize)
        {
            // 現在のスケールを元にサイズを増やす
            bullet.transform.localScale = bulletScale;
            Debug.Log("Big");
        }

    }





    void AttackPattern4()
    {
        for (int i = 0; i < randomCount; i++)
        {
            // ランダムな角度を生成 (0度から360度)
            float randomAngle = UnityEngine.Random.Range(90f, 270f);

            // 弾を生成
            GameObject bullet = Instantiate(forePrefab, transform.position, Quaternion.identity);

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

}
