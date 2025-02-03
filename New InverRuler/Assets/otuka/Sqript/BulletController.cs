using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̒e�ہA���˂��Ǘ�����X�N���v�g
/// </summary>
public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;//�v���C���[�̒e�̃v���n�u
    public Transform firePoint;//�v���C���[�̒e�̔��ˈʒu
    public Text ammoText;//�v���C���[�̒e�̌��݂̎c��e��
    public float bulletSpeed = 10f; // �e�̑��x
    public int bulletDamage = 5;//�e�̈З�
    public int maxBullets = 10;//�e�̍ő吔
    private int currentBullets;
    public AudioSource shootAudioSource; // ���ˌ��ʉ��p

    private PlayerController playerController; // PlayerController�̎Q��

    void Start()
    {
        currentBullets = maxBullets;//maxBullets��currentBullets�ɓ����
        UpdateAmmoText();
        playerController = FindObjectOfType<PlayerController>(); // PlayerController��������
    }

    void Update()
    {
        // �Q�[���̏�Ԃ��m�F���Ă���e�𔭎�
        if (playerController != null && PlayerController.gameState == "playing" && Input.GetMouseButtonDown(0) && currentBullets > 0) // �E�N���b�N
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

    public void AddBullets(int amount)//�e�̎c��e����ω�������
    {
        currentBullets += amount;
        if (currentBullets > maxBullets)
        {
            currentBullets = maxBullets;
        }
        UpdateAmmoText();
    }

    void UpdateAmmoText()//�e�̎c��e����\������
    {
        ammoText.text = "�~ " + currentBullets;
    }
}



