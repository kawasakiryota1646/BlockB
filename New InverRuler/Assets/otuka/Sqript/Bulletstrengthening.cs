using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bulletstrengthening : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // �_���[�W���ʉ��p
    void Start()
    {
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
    }

    void ChangeBulletDamage()
    {

        if (CoinManager.instance.coinCount >= 30)
        {
            // �_���[�W���ʉ����Đ�
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(30);
            friendBULLET.damage += 1f; // �_���[�W��+5����
        }
        else
        {
            Debug.Log("�R�C��������܂���");
        }
    }
}
