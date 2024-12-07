using UnityEngine;
using UnityEngine.UI;

public class ChangeDamage : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // ダメージ効果音用
    void Start()
    {
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
    }

    void ChangeBulletDamage()
    {

        if (CoinManager.instance.coinCount >= 20)
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(20);
            AttckBullet.damage += 5f; // ダメージを+5する
        }
        else
        {
            Debug.Log("コインが足りません");
        }
    }
}
