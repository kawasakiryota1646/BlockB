using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USA_hard_Attack : MonoBehaviour
{
    public GameObject UKIPrefab; //�e�̃v���n�u
    public GameObject POTATOPrefab; //�e�̃v���n�u
    public GameObject hamburgerPrefab; //�e�̃v���n�u
    public GameObject SNOWPrefab; //�e�̃v���n�u
    public Transform firePoint;     //���ˈʒu�̃v���n�u
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    public float fireInterval = 5f; // ���ˊԊu

    private float lastAttackTime;
    private USA_hardHP bossHealth;      //�{�X�̗̑�


    public float POTATOSpeed = 5f;

    public float shootInterval = 1.5f; // �e�����Ԋu
    public int bulletCount = 12;     // ���˂���e�̐�
    public float burgerSpeed = 5f;   // �e�̑��x
    public float angleRange = 180f; // ���˂���͈�


    public float spawnInterval = 0.2f; // �e�𐶐�����Ԋu
    public int bulletsPerWave = 10;   // 1��̃E�F�[�u�ō~�点��e�̐�
    public float rainbulletSpeed = 5f;    // �e�̗������x
    public float spawnAreaWidth = 10f; // �e�����������͈͂̕�



    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = -attackCooldown; // �ŏ��̍U���������ɂł���悤�ɐݒ�
        bossHealth = GetComponentInParent<USA_hardHP>(); // �e�I�u�W�F�N�g����BossHealth���擾

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 750)
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 500)
                {
                    AttackPattern2();
                }
                else if (bossHealth.currentHealth > 250)
                {
                    AttackPattern3();
                }
                else
                {
                    AttackPattern4();
                }

                lastAttackTime = Time.time; // �Ō�̍U�����Ԃ��X�V
            }
        }

    }

    void AttackPattern1()//�O����
    {
        int bulletCount = 3; // �e�̐�
        float spreadAngle = 50f; // ���̊p�x

        for (int i = 0; i < bulletCount; i++)
        {
            // �e�̊p�x���v�Z
            float angle = -spreadAngle / 2 + spreadAngle / (bulletCount - 1) * i;

            // ���˕������v�Z
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // �e�𐶐�
            GameObject bullet = Instantiate(UKIPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2D�ő��x��^����
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern2()//����
    {
        POTATOFire(); // �e�𔭎�
    }

    void POTATOFire()
    {
        // �e�𐶐�
        GameObject bullet = Instantiate(POTATOPrefab, firePoint.position, Quaternion.identity);

        // �e���������ɔ�΂�
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * POTATOSpeed; // ��ɉ������ɔ���
        }

        // �e�̎������Łi��: 5�b��ɍ폜�j
        Destroy(bullet, 5f);
    }

    void AttackPattern3()//6����
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
            // �����_����X���W���v�Z
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

            // �e�𐶐�
            GameObject bullet = Instantiate(SNOWPrefab, spawnPosition, Quaternion.identity);

            // �e�ɑ��x��^����
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * rainbulletSpeed;
            }
        }
    }

}
