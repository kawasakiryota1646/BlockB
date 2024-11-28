using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBail : MonoBehaviour
{
    public float speed = 5f; // �ʂ̈ړ����x
    public float growthRate = 0.1f; // �ʂ��������鑬��
    public float maxSize = 3f; // �ʂ̍ő�T�C�Y
    private Vector3 initialScale; // �����̃X�P�[���i�T�C�Y�j

    void Start()
    {
        initialScale = transform.localScale; // �ʂ̏����X�P�[����ۑ�
    }

    void Update()
    {
        // �ʂ����Ɉړ�����
        MoveDown();

        // �ʂ�傫������
        Grow();
    }

    void MoveDown()
    {
        // �ʂ����ɐi�ށiY�������Ɉړ��j
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Grow()
    {
        // �ʂ̌��݂̃X�P�[�����擾
        Vector3 currentScale = transform.localScale;

        // �ʂ��ő�T�C�Y�ɒB���Ă��Ȃ��ꍇ�A����������
        if (currentScale.x < maxSize && currentScale.y < maxSize)
        {
            // ���݂̃X�P�[�������ɃT�C�Y�𑝂₷
            transform.localScale = new Vector3(
                currentScale.x + growthRate * Time.deltaTime,
                currentScale.y + growthRate * Time.deltaTime,
                currentScale.z
            );
        }
    }
}
