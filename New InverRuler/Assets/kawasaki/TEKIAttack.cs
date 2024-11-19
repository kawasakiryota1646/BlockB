using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEKIAttack : MonoBehaviour
{
    public GameObject bulletPrefab; //�e�̃v���n�u
    public GameObject laserPrefab;
    public Transform firePoint;     //���ˈʒu�̃v���n�u
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private TEKIHP bossHealth;      //�{�X�̗̑�
    private float spiralAngle = 0f;

    public float randomSpeed = 5f;  // �e�̑��x
    public int   randomCount = 10;    // ���˂���e�̐�


    void Start()
    {
        lastAttackTime = -attackCooldown; // �ŏ��̍U���������ɂł���悤�ɐݒ�
        bossHealth = GetComponentInParent<TEKIHP>(); // �e�I�u�W�F�N�g����BossHealth���擾

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 50)
                {
                    AttackPattern1(8);
                }
                else if (bossHealth.currentHealth > 20)
                {
                    AttackPattern2();
                }
                else
                {
                    AttackPattern3();
                }
                lastAttackTime = Time.time; // �Ō�̍U�����Ԃ��X�V
            }
        }
    }
    void AttackPattern1(int bulletCount)//�~�`
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float radian = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
            FireBullet(direction);
            angle += angleStep;
        }


    }

    void FireBullet(Vector3 direction)//�z�[�~���O
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void AttackPattern2()//�����_��
    {
        for (int i = 0; i < randomCount; i++)
        {
            // �����_���Ȋp�x�𐶐� (0�x����360�x)
            float randomAngle = Random.Range(0f, 360f);

            // �e�𐶐�
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // ���˕�����ݒ�
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

            // Rigidbody2D ���g�p���Ēe�𔭎�
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * randomSpeed;
            }
        }

    }

    void AttackPattern3()
    {
       

    }



}


