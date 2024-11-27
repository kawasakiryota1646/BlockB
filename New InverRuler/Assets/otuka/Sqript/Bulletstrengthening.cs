using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bulletstrengthening : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // ダメージ効果音用
    void Start()
    {
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
    }

    void ChangeBulletDamage()
    {

        if (CoinManager.instance.coinCount >= 30)
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(30);
            friendBULLET.damage += 1f; // ダメージを+5する
        }
        else
        {
            Debug.Log("コインが足りません");
        }
    }
}
