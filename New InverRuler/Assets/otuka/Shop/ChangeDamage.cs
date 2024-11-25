using UnityEngine;
using UnityEngine.UI;

public class ChangeDamage : MonoBehaviour
{
    public Button changeDamageButton;

    void Start()
    {
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
    }

    void ChangeBulletDamage()
    {
        if (CoinManager.instance.coinCount >= 20)
        {
            CoinManager.instance.RemoveCoins(20);
            AttckBullet.damage += 5f; // �_���[�W��+5����
        }
        else
        {
            Debug.Log("�R�C��������܂���");
        }
    }
}
