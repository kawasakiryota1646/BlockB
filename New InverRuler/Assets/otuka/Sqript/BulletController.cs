using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの弾丸、発射を管理するスクリプト
/// </summary>
public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;//プレイヤーの弾のプレハブ
    public Transform firePoint;//プレイヤーの弾の発射位置
    public Text ammoText;//プレイヤーの弾の現在の残り弾数
    public float bulletSpeed = 10f; // 弾の速度
    public int bulletDamage = 5;//弾の威力
    public int maxBullets = 10;//弾の最大数
    private int currentBullets;
    public AudioSource shootAudioSource; // 発射効果音用

    private PlayerController playerController; // PlayerControllerの参照

    void Start()
    {
        currentBullets = maxBullets;//maxBulletsをcurrentBulletsに入れる
        UpdateAmmoText();
        playerController = FindObjectOfType<PlayerController>(); // PlayerControllerを見つける
    }

    void Update()
    {
        // ゲームの状態を確認してから弾を発射
        if (playerController != null && PlayerController.gameState == "playing" && Input.GetMouseButtonDown(0) && currentBullets > 0) // 右クリック
        {
            // 発射効果音を再生
            if (shootAudioSource != null)
            {
                shootAudioSource.Play();
            }
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed; // 上方向に発射
        currentBullets--;
        UpdateAmmoText();
        // 弾がゼロになったら回復アイテムを生成する
        if (currentBullets == 0)
        {
            FindObjectOfType<Healitem>().StartSpawningAmmo();
        }
    }

    public void AddBullets(int amount)//弾の残り弾数を変化させる
    {
        currentBullets += amount;
        if (currentBullets > maxBullets)
        {
            currentBullets = maxBullets;
        }
        UpdateAmmoText();
    }

    void UpdateAmmoText()//弾の残り弾数を表示する
    {
        ammoText.text = "× " + currentBullets;
    }
}



