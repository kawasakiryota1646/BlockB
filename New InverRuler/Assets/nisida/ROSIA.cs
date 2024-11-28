using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROSIA : MonoBehaviour
{
    public GameObject onePrefab; //�e�̃v���n�u
    public GameObject twoPrefab; //�e�̃v���n�u
    public GameObject threePrefab; //�e�̃v���n�u
    public GameObject forePrefab; //�e�̃v���n�u
    public Transform firePoint;     //���ˈʒu�̃v���n�u
    public float attackCooldown = 1.0f;
    private float lastAttackTime;
    private TEKIHP bossHealth;      //�{�X�̗̑�

    public float fireRate = 1f;      // ���ˊԊu
    public float bulletSpeed = 5f;   // �e�̑��x
    private float nextFireTime = 0f; // ���ɒe�𔭎˂��鎞��

    public int randomCount = 10;
    public float randomSpeed = 5f;

    public float speed = 10000f; // �u�[�������̈ړ����x
    public float returnSpeed = 5f; // �߂鎞�̃X�s�[�h
    public float maxDistance = 20f; // �u�[���������i�ލő勗��
    private Vector3 startPosition; // ���ˈʒu
    private bool isReturning = false; // �߂蒆���ǂ���
    private Transform player; // �v���C���[�̈ʒu

    public float snowspeed = 5f; // �ʂ̈ړ����x
    public float growthRate = 0.1f; // �ʂ��������鑬��
    public float maxSize = 100f; // �ʂ̍ő�T�C�Y
    private Vector3 initialScale; // �����̃X�P�[���i�T�C�Y�j




    void Start()
    {
        lastAttackTime = -attackCooldown; // �ŏ��̍U���������ɂł���悤�ɐݒ�
        bossHealth = GetComponentInParent<TEKIHP>(); // �e�I�u�W�F�N�g����BossHealth���擾

        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // �v���C���[������

        initialScale = transform.localScale; // �ʂ̏����X�P�[����ۑ�


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
                else if (bossHealth.currentHealth > 24)
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

        FireBullet();
    }

    void FireBullet()
    {
        // �e�𐶐�
        GameObject bullet = Instantiate(onePrefab, transform.position, Quaternion.identity);

        // �e�ɑ��x��^���ĉ������Ɉړ�������
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * bulletSpeed; // �e���������Ɉړ�
        }
    }

    void AttackPattern2()
    {
        GameObject bullet = Instantiate(twoPrefab, transform.position, Quaternion.identity);

        // �u�[���������߂��Ă���ꍇ�́A�v���C���[�ʒu�Ɍ������Ė߂�
        if (isReturning)
        {
            ReturnToPlayer();
        }
        else
        {
            // �u�[��������O�i������
            MoveForward(bullet);
        }

    }

    void MoveForward(GameObject bullet)
    {
        // �u�[���������ő勗���ɓ��B������߂�
        float distanceTravelled = Vector3.Distance(player.position, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            isReturning = true;
        }

        // �u�[���������v���C���[�Ɍ������Ĕ��ł���ꍇ
        Vector3 direction = player.position - transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed * Time.deltaTime;
    }

    void ReturnToPlayer()
    {
        

        // �v���C���[�Ɍ������Ė߂�
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * returnSpeed * Time.deltaTime;

        // �v���C���[�ɓ��B������A�U�������������̂Ŏ������g���폜
        if (Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }


    void AttackPattern3()
    {

        GameObject bullet;
        // �ʂ����Ɉړ�����
        bullet = MoveDown();

        // �ʂ�傫������
        Grow(bullet);

    }

    GameObject MoveDown()
    {
        GameObject bullet = Instantiate(threePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * snowspeed; // �e���������Ɉړ�

        }
        return bullet;
    }

    void Grow(GameObject bullet)
    {
        // �ʂ̌��݂̃X�P�[�����擾
        Vector3 currentScale = bullet.transform.localScale;
        Vector3 bulletScale;

        bulletScale.x = currentScale.x + growthRate * bullet.transform.position.y;
        bulletScale.y = currentScale.y + growthRate * bullet.transform.position.y;
        bulletScale.z = currentScale.z;

        // �ʂ��ő�T�C�Y�ɒB���Ă��Ȃ��ꍇ�A����������
        if (currentScale.x < maxSize && currentScale.y < maxSize)
        {
            // ���݂̃X�P�[�������ɃT�C�Y�𑝂₷
            bullet.transform.localScale = bulletScale;
            Debug.Log("Big");
        }

    }




    void AttackPattern4()
    {
        for (int i = 0; i < randomCount; i++)
        {
            // �����_���Ȋp�x�𐶐� (0�x����360�x)
            float randomAngle = UnityEngine.Random.Range(90f, 270f);

            // �e�𐶐�
            GameObject bullet = Instantiate(forePrefab, transform.position, Quaternion.identity);

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

}
