using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Text ammoText;
    public float bulletSpeed = 10f; // �e�̑��x
    public int bulletDamage = 5;
    public int maxBullets = 10;
    private int currentBullets;
    public AudioSource shootAudioSource; // ���ˌ��ʉ��p

    private PlayerController playerController; // PlayerController�̎Q��

    void Start()
    {
        currentBullets = maxBullets;
        UpdateAmmoText();
        playerController = FindObjectOfType<PlayerController>(); // PlayerController��������
    }

    void Update()
    {
        // �Q�[���̏�Ԃ��m�F���Ă���e�𔭎�
        if (playerController != null && PlayerController.gameState == "playing" && Input.GetMouseButtonDown(1) && currentBullets > 0) // �E�N���b�N
        {
            // ���ˌ��ʉ����Đ�
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
        rb.velocity = Vector2.up * bulletSpeed; // ������ɔ���
        currentBullets--;
        UpdateAmmoText();
        // �e���[���ɂȂ�����񕜃A�C�e���𐶐�����
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
        ammoText.text = "�~ " + currentBullets;
    }
}



