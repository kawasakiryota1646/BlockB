using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int ammoAmount = 5;//�e�̉񕜐�
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//�v���C���[�^�O�ɔ�������
        {
            
            other.GetComponent<BulletController>().AddBullets(ammoAmount);//BulletController���R���|�[�l���g���Ēe���񕜂�����
            FindObjectOfType<Healitem>().OnAmmoCollected();
            Destroy(gameObject);
        }
    }
}
