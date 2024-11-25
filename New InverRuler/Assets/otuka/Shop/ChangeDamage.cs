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
            AttckBullet.damage += 5f; // ダメージを+5する
        }
        else
        {
            Debug.Log("コインが足りません");
        }
    }
}
