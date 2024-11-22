using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSMOVE : MonoBehaviour
{
    public float moveSpeed = 3f;          // �{�X�̈ړ����x
    public float changeDirectionInterval = 2f; // �ړ�������ς���Ԋu
    private Vector2 targetPosition;       // �ړ���̈ʒu
    private float timer = 0f;             // �^�C�}�[

    // �G���A�̐����͈�
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        SetRandomTargetPosition();        // �ŏ��̈ړ��������
    }

    void Update()
    {
        timer += Time.deltaTime;

        // �w�肵�����ԊԊu���ƂɃ����_���ȕ����Ɉړ�
        if (timer >= changeDirectionInterval)
        {
            SetRandomTargetPosition();
            timer = 0f;  // �^�C�}�[�����Z�b�g
        }

        // �ړ���Ɍ������ă{�X���ړ�������
        MoveTowardsTarget();
    }

    // �����_���Ȉړ��������i�G���A���ɐ����j
    void SetRandomTargetPosition()
    {
        // �w�肳�ꂽ�G���A���Ń����_���Ȉʒu������
        float randomX = Random.Range(minX, maxX);  // X���͈̔�
        float randomY = Random.Range(minY, maxY);  // Y���͈̔�

        targetPosition = new Vector2(randomX, randomY);  // �����_���Ȉʒu���^�[�Q�b�g�Ƃ��Đݒ�
    }

    // �{�X���^�[�Q�b�g�ʒu�Ɍ������Ĉړ�������
    void MoveTowardsTarget()
    {
        // ���݂̃{�X�̈ʒu����^�[�Q�b�g�ʒu�܂ł̕������v�Z
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // �{�X�����̕����Ɉړ�������
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
