using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class syake : MonoBehaviour
{
    public float speed = 10f; // �u�[�������̈ړ����x
    public float returnSpeed = 5f; // �߂鎞�̃X�s�[�h
    public float maxDistance = 20f; // �u�[���������i�ލő勗��
    private Vector3 startPosition; // ���ˈʒu
    private bool isReturning = false; // �߂蒆���ǂ���
    private Transform player; // �v���C���[�̈ʒu

    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform; // �v���C���[������
    }

    void Update()
    {
        // �u�[���������߂��Ă���ꍇ�́A�v���C���[�ʒu�Ɍ������Ė߂�
        if (isReturning)
        {
            ReturnToPlayer();
        }
        else
        {
            // �u�[��������O�i������
            MoveForward();
        }
    }

    void MoveForward()
    {
        // �u�[���������ő勗���ɓ��B������߂�
        float distanceTravelled = Vector3.Distance(startPosition, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            isReturning = true;
        }

        // �u�[���������v���C���[�Ɍ������Ĕ��ł���ꍇ
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
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

}
