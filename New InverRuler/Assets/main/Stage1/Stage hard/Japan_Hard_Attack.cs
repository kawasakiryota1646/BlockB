using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japan_Hard_Attack : MonoBehaviour
{
    public GameObject SakuraPrefab;      //�e�̃v���n�u
    public GameObject SunflowerPrefab;   //�e�̃v���n�u
    public GameObject FallfoliagePrefab; //�e�̃v���n�u
    public GameObject SnowflakesPrefab;  //�e�̃v���n�u
    public Transform firePoint;          //���ˈʒu�̃v���n�u
    public float bulletSpeed = 5f;       //���̒e��
    public float attackCooldown = 1.0f;  //���̒e�̊Ԋu
    public int Sunflower_bulletCount = 4;// �e�̐�
    public float spreadAngle = 50f;      // ���̊p�x
    private float lastAttackTime;
    private Japan_Hard_HP bossHealth;    //�{�X�̗̑�
    public float randomSpeed = 5f;       // �g�t�̒e�̑��x
    public int randomCount = 10;         // �g�t�̔��˂���e�̐�
    public int Snowflakes_bulletCount = 20;// ��̌����̒e�̐�
    public float rotationSpeed = 50f; // �����̉�]���x
    public float positionOffset = 1f; // ���ˈʒu�̂��炵��


    void Start()
    {
        lastAttackTime = -attackCooldown; // �ŏ��̍U���������ɂł���悤�ɐݒ�
        bossHealth = GetComponentInParent<Japan_Hard_HP>(); // �e�I�u�W�F�N�g����BossHealth���擾

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 225)//�{�X��HP��225�ȏ�Ȃ���`��
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 150)//�{�X��HP��150�ȏ�Ȃ���`��
                {
                    AttackPattern2();
                }
                else if (bossHealth.currentHealth > 75)//�{�X��HP��75�ȏ�Ȃ��O�`��
                {
                    AttackPattern3();
                }
                else//�{�X��HP��75�ȉ��Ȃ��l�`��
                {
                    AttackPattern4();
                }
                lastAttackTime = Time.time; // �Ō�̍U�����Ԃ��X�V
            }
        }
    }
    void AttackPattern1()//�^�������e������
    {
        Sakura();
    }

    void Sakura()
    {
        GameObject bullet = Instantiate(SakuraPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed; // �������ɔ���
    }

    void AttackPattern2()//�U�e
    {

        for (int i = 0; i < Sunflower_bulletCount; i++)
        {
            // �e�̊p�x���v�Z
            float angle = -spreadAngle / 2 + spreadAngle / (Sunflower_bulletCount - 1) * i;

            // ���˕������v�Z
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // �e�𐶐�
            GameObject bullet = Instantiate(SunflowerPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2D�ő��x��^����
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern3()//�����_��
    {
        for (int i = 0; i < randomCount; i++)
        {
            // �����_���Ȋp�x�𐶐� (0�x����360�x)
            float randomAngle = Random.Range(90f, 270f);

            // �e�𐶐�
            GameObject bullet = Instantiate(FallfoliagePrefab, transform.position, Quaternion.identity);

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

    void AttackPattern4()//�~�`�ɍU��
    {
        Snowflakes();
    }

    void Snowflakes()
    {
        for (int i = 0; i < Snowflakes_bulletCount; i++)
        {
            // ���˂���p�x���v�Z�i���̊Ԋu�Ŋp�x�𑝉�������j
            float angle = i * (360f / Snowflakes_bulletCount) + rotationSpeed * i * Time.deltaTime;

            // ���ˈʒu�����E�ɂ��炷�isin�ňʒu���㉺�ɓ������j
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset; // �ʒu�����E�ɓ�����

            // ���炵�����ˈʒu��ݒ�
            Vector2 adjustedFirePosition = new Vector2(firePoint.position.x + offsetX, firePoint.position.y);

            // �������v�Z
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // �e�𔭎�
            GameObject bullet = Instantiate(SnowflakesPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed; // �v�Z���������ɒe���΂�
            }
        }
    }

}
