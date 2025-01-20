using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Japan_normal_Attack : MonoBehaviour
{
    //�{�X��HP�̎c��̊���   (�萔)
    const int FIRST_STEP = 74;
    const int SECOND_STEP = 49;
    const int THIRD_STEP = 24;

    //�e�A���ˈʒu�̃v���n�u
    public GameObject SakuraPrefab;              //��i�K�ڂ̒e�̃v���n�u
    public GameObject SunflowerPrefab;           //��i�K�ڂ̒e�̃v���n�u
    public GameObject FallfoliagePrefab;         //�O�i�K�ڂ̒e�̃v���n�u
    public GameObject SnowflakesPrefab;          //�l�i�K�ڂ̒e�̃v���n�u
    public Transform FirePoint;                  //���ˈʒu�̃v���n�u

    public float AttackCooldown;                 //�U���̃N�[���_�E��
    public float BulletSpeed;                    //�S�̂̒e��

    //��i�K��
    public int   Sunflower_bulletCount;          //�e�̐�
    public float spreadAngle;                    //���̊p�x

    //�O�i�K��
    public float Fallfoliage_randomSpeed;        //�e�̑��x
    public int   Fallfoliage_randomCount;        //���˂���e�̐�

    //�l�i�K��
    public float Snowflakes_rotationSpeed;       // �����̉�]���x
    public int   Snowflakes_bulletCount;         // ���˂���e�̐�
    public float positionOffset;                 // ���ˈʒu�̂��炵��

    private float lastAttackTime;
    private Japan_normal_HP BossHealth;          //�{�X�̗̑�

    void Start()
    {
        lastAttackTime = -AttackCooldown;                   �@// �ŏ��̍U���������ɂł���悤�ɐݒ�
        BossHealth = GetComponentInParent<Japan_normal_HP>(); // �e�I�u�W�F�N�g����BossHealth���擾

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + AttackCooldown)
        {
            if (BossHealth != null)         //HP�̗ʂōU���p�^�[�����ω�����
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
                lastAttackTime = Time.time; // �Ō�̍U�����Ԃ��X�V
            }
        }
    }


    //��i�K�ڂ̍U��
    //�������ɒe�������
    void Spring()
    {
        GameObject bullet = Instantiate(SakuraPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * BulletSpeed; // �������ɔ���

    }

    //��i�K�ڂ̍U��
    //�������ɎU�e������
    void Summer()
    {
        for (int i = 0; i < Sunflower_bulletCount; i++)
        {
            // �e�̊p�x���v�Z
            float angle = -spreadAngle / 2 + spreadAngle / (Sunflower_bulletCount - 1) * i;

            // ���˕������v�Z
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // �e�𐶐�
            GameObject bullet = Instantiate(SunflowerPrefab, FirePoint.position, Quaternion.identity);

            // Rigidbody2D�ő��x��^����
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * BulletSpeed;
            }
        }

    }

    //�O�i�K�ڂ̍U��
    //�������ɐ��ɒe������
    void Fall()
    {
        for (int i = 0; i < Fallfoliage_randomCount; i++)
        {
            // �����_���Ȋp�x�𐶐� (90�x����270�x)
            float randomAngle = Random.Range(90f, 270f);

            // �e�𐶐�
            GameObject bullet = Instantiate(FallfoliagePrefab, transform.position, Quaternion.identity);

            // ���˕�����ݒ�
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * Vector3.up;

            // Rigidbody2D ���g�p���Ēe�𔭎�
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * Fallfoliage_randomSpeed;
            }
        }

    }

    //�l�i�K�ڂ̍U��
    //�~�`��ɒe������
    void Winter()
    {
        for (int i = 0; i < Snowflakes_bulletCount; i++)
        {
            // ���˂���p�x���v�Z
            float angle = i * (360f / Snowflakes_bulletCount) + Snowflakes_rotationSpeed * i * Time.deltaTime;

            // ���ˈʒu�����E�ɂ��炷
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset;

            // ���炵�����ˈʒu��ݒ�
            Vector2 adjustedFirePosition = new Vector2(FirePoint.position.x + offsetX, FirePoint.position.y);

            // �������v�Z
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // �e�𔭎�
            GameObject bullet = Instantiate(SnowflakesPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // �v�Z���������ɒe���΂�
            if (rb != null)
            {
                rb.velocity = direction * BulletSpeed; 
            }
        }
    }
}


