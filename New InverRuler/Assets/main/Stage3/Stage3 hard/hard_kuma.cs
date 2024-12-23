using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hard_kuma : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public float fireRate = 0.1f;   // �e�̔��ˊԊu
    public int bulletCount = 30;     // ���˂���e�̐�
    public float spreadAngle = 360f; // ���˂���e�̊p�x�͈�
    public float bulletSpeed = 5f;   // �e�̑��x

    private void Start()
    {
        // �e���𔭎˂���R���[�`�����J�n
        StartCoroutine(FireBulletPattern());
    }

    private IEnumerator FireBulletPattern()
    {
        while (true) // �����ɒe���𔭎˂�������
        {
            // �e����˂���p�x���v�Z
            float angleStep = spreadAngle / bulletCount;
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = -spreadAngle / 2f + angleStep * i;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.up;

                // �e�𐶐�
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                // �e�̊Ԋu��ҋ@
                yield return new WaitForSeconds(fireRate);
            }

            // ��x�e����ł��I������ɏ����҂i�I�v�V�����j
            yield return new WaitForSeconds(1f);
        }
    }
}
