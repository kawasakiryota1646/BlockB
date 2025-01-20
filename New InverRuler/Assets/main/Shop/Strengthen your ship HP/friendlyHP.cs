using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class friendlyHP : MonoBehaviour
{
    public AudioSource Button_Audio;
    bool first_Button = false;
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // ダメージ効果音用
    public Text insufficientCoinsText; // コイン不足メッセージ用
    public GameObject insufficientCoinsObject; // コイン不足時に表示するオブジェクト
    public Text costText; // 値段表示用のTextコンポーネント
    private int purchaseCount; // 購入回数を管理する変数
    private int baseCost = 50; // 基本のコイン消費量
    public AudioSource Lackofcoins;//買えなかった時に鳴らすSE
    void Start()
    {

        purchaseCount = PlayerPrefs.GetInt("Number of Life Purchases", 0); // 保存された購入回数を読み込む
        FriendController.hp1 = PlayerPrefs.GetInt("Number of Lives", 1); // 保存されたHPの威力を読み込む
        FriendController2.hp2 = PlayerPrefs.GetInt("Number of Lives", 1); // 保存されたHPの威力を読み込む
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
        insufficientCoinsText.gameObject.SetActive(false); // 初期状態では非表示
        insufficientCoinsObject.SetActive(false); // 初期状態では非表示

        UpdateCostText(); // 初期値を表示
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 10); // 現在のコイン消費量を計算

        if (CoinManager.coinCount >= currentCost && FriendController.hp1 < 3f)
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);

            FriendController.hp1 += 1; // ダメージを+1する
            FriendController2.hp2 += 1;
            if (FriendController.hp1 > 3f)
            {
               FriendController.hp1 = 3; // 上限を5に設定
            }
            if (FriendController2.hp2 > 3f)
            {
                FriendController2.hp2 = 3; // 上限を5に設定
            }
            PlayerPrefs.SetInt("Number of Lives", FriendController.hp1); // 弾の威力を保存
            PlayerPrefs.SetInt("Number of Lives", FriendController2.hp2); // 弾の威力を保存
            insufficientCoinsText.gameObject.SetActive(false); // コインが足りている場合は非表示
            insufficientCoinsObject.SetActive(false); // コインが足りている場合は非表示
            purchaseCount++; // 購入回数を増やす
            PlayerPrefs.SetInt("Number of Life Purchases", purchaseCount); // 購入回数を保存
            UpdateCostText(); // 値段を更新
        }
        else if (FriendController.hp1 >= 3)
        {
            if (Lackofcoins != null)
            {
                Lackofcoins.Play();//買えなかった時に鳴らす
            }
            insufficientCoinsText.text = "HPは最大です"; // 上限に達したメッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
        else
        {
            if (Lackofcoins != null)
            {
                Lackofcoins.Play();//買えなかった時に鳴らす
            }
            insufficientCoinsText.text = "コインが足りません"; // メッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
    }

    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * 10); // 現在のコイン消費量を計算
        costText.text = "×" + currentCost.ToString() + ""; // 値段を表示
    }

    public void OnMouseEnter()
    {
        if (first_Button == false)
        {
            Button_Audio.Play();
            first_Button = true;
        }
    }

    public void OnMouseExit()
    {
        first_Button = false;
    }
}
