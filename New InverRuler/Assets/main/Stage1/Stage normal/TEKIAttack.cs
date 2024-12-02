using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEKIAttack : MonoBehaviour
{
    public GameObject SAKURAPrefab; //�e�̃v���n�u
    public GameObject HIMAWARIPrefab; //�e�̃v���n�u
    public GameObject MOMIZIPrefab; //�e�̃v���n�u
    public GameObject SNOWPrefab; //�e�̃v���n�u
    public Transform firePoint;     //���ˈʒu�̃v���n�u
    public float bulletSpeed = 5f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private JapanHP bossHealth;      //�{�X�̗̑�
    public float randomSpeed = 5f;  // �e�̑��x
    public int   randomCount = 10;    // ���˂���e�̐�




    public float rotationSpeed = 50f; // �����̉�]���x
    public int bulletCount = 20;      // ���˂���e�̐�
    public float positionOffset = 1f; // ���ˈʒu�̂��炵��

    void Start()
    {
        lastAttackTime = -attackCooldown; // �ŏ��̍U���������ɂł���悤�ɐݒ�
        bossHealth = GetComponentInParent<JapanHP>(); // �e�I�u�W�F�N�g����BossHealth���擾

    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (bossHealth != null)
            {
                if (bossHealth.currentHealth > 74)
                {
                    AttackPattern1();
                }
                else if (bossHealth.currentHealth > 49)
                {
                    AttackPattern2();
                }
                else if(bossHealth.currentHealth > 24)
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
    void AttackPattern1()
    {
        Fire();
    }

    void Fire()
    {
        GameObject bullet = Instantiate(SAKURAPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed; // �������ɔ���
    }

    void AttackPattern2()//�����_��
    {
        int bulletCount = 4; // �e�̐�
        float spreadAngle = 50f; // ���̊p�x

        for (int i = 0; i < bulletCount; i++)
        {
            // �e�̊p�x���v�Z
            float angle = -spreadAngle / 2 + spreadAngle / (bulletCount - 1) * i;

            // ���˕������v�Z
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

            // �e�𐶐�
            GameObject bullet = Instantiate(HIMAWARIPrefab, firePoint.position, Quaternion.identity);

            // Rigidbody2D�ő��x��^����
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    }

    void AttackPattern3()
    {
        for (int i = 0; i < randomCount; i++)
        {
            // �����_���Ȋp�x�𐶐� (0�x����360�x)
            float randomAngle = Random.Range(90f, 270f);

            // �e�𐶐�
            GameObject bullet = Instantiate(MOMIZIPrefab, transform.position, Quaternion.identity);

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

    void AttackPattern4()
    {
        FireSpiral();
    }

    void FireSpiral()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            // ���˂���p�x���v�Z�i���̊Ԋu�Ŋp�x�𑝉�������j
            float angle = i * (360f / bulletCount) + rotationSpeed * i * Time.deltaTime;

            // ���ˈʒu�����E�ɂ��炷�isin�ňʒu���㉺�ɓ������j
            float offsetX = Mathf.Sin(Time.time * 2f) * positionOffset; // �ʒu�����E�ɓ�����

            // ���炵�����ˈʒu��ݒ�
            Vector2 adjustedFirePosition = new Vector2(firePoint.position.x + offsetX, firePoint.position.y);

            // �������v�Z
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // �e�𔭎�
            GameObject bullet = Instantiate(SNOWPrefab, adjustedFirePosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed; // �v�Z���������ɒe���΂�
            }
        }
    }


}


