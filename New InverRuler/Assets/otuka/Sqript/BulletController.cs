using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Text ammoText;
    public float bulletSpeed = 10f; // 弾の速度
    public int bulletDamage = 5;
    public int maxBullets = 10;
    private int currentBullets;
    public AudioSource shootAudioSource; // 発射効果音用

    private PlayerController playerController; // PlayerControllerの参照

    void Start()
    {
        currentBullets = maxBullets;
        UpdateAmmoText();
        playerController = FindObjectOfType<PlayerController>(); // PlayerControllerを見つける
    }

    void Update()
    {
        // ゲームの状態を確認してから弾を発射
        if (playerController != null && PlayerController.gameState == "playing" && Input.GetMouseButtonDown(1) && currentBullets > 0) // 右クリック
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

    public void AddBullets(int amount)
    {
        currentBullets += amount;
        if (currentBullets > maxBullets)
        {
            currentBullets = maxBullets;
        }
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "× " + currentBullets;
    }
}



