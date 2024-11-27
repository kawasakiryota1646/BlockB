using UnityEngine;
using UnityEngine.UI;

public class ChangeDamage : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // �_���[�W���ʉ��p
    void Start()
    {
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
    }

    void ChangeBulletDamage()
    {

        if (CoinManager.instance.coinCount >= 20)
        {
            // �_���[�W���ʉ����Đ�
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(20);
            AttckBullet.damage += 5f; // �_���[�W��+5����
        }
        else
        {
            Debug.Log("�R�C��������܂���");
        }
    }
}