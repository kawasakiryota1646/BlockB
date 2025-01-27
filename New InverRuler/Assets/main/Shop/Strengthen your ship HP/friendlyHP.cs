using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class friendlyHP : MonoBehaviour
{
    public AudioSource buttonAudio;//ボタンの上にマウスポインタが来たら音を鳴らすAudio
    bool firstButton = false;//
    public Button changeHP;//HPを変更するボタン
    public AudioSource coinAudioSource; // ダメージ効果音用
    public Text insufficientCoinsText; // コイン不足メッセージ用
    public GameObject insufficientCoinsObject; // コイン不足時に表示するオブジェクト
    public Text costText; // 値段表示用のTextコンポーネント
    private int purchaseCount; // 購入回数を管理する変数
    private int baseCost = 50; // 基本のコイン消費量
    public AudioSource lackofcoins;//買えなかった時に鳴らすSE
    const int MAXIMUMHP = 3;//最大HPを定数化
    const int PRESENT = 10;//最初の必要なコインの枚数を定数化
    const int INCREASE = 1;//増加するHPの値を定数化
    //スタート関数
    void Start()
    {

        purchaseCount = PlayerPrefs.GetInt("Number of Life Purchases", 0); // 保存された購入回数を読み込む
        FriendController.hp1 = PlayerPrefs.GetInt("Number of Lives", 1); // 保存された味方機体1HPを読み込む
        FriendController2.hp2 = PlayerPrefs.GetInt("Number of Lives", 1); // 保存された味方機体2HPを読み込む
        changeHP.onClick.AddListener(ChangeHP);//ボタンを押したらHPを増やす関数に移動する
        insufficientCoinsText.gameObject.SetActive(false); // 初期状態では非表示
        insufficientCoinsObject.SetActive(false); // 初期状態では非表示

        UpdateCostText(); // 初期値を表示
    }

    //チェンジ関数
    void ChangeHP()
    {
        int currentCost = baseCost + (purchaseCount * PRESENT); // 現在のコイン消費量を計算

        if (CoinManager.coinCount >= currentCost && FriendController.hp1 < MAXIMUMHP)//コインの枚数が値段より高く　HPが3以下なら中の処理を実行
        {
            // ダメージ効果音を再生
            if (coinAudioSource != null)
            {
                coinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);//CoinManagerを取得

            FriendController.hp1 += INCREASE; // 味方機体1HPを+1する
            FriendController2.hp2 += INCREASE;//味方機体2HPを+1する

            if (FriendController.hp1 > MAXIMUMHP)//味方機体1HPが3f以上になるなら3fに直す
            {
               FriendController.hp1 = MAXIMUMHP; 
            }

            if (FriendController2.hp2 > MAXIMUMHP)//味方機体2HPが3f以上になるなら3fに直す
            {
                FriendController2.hp2 = MAXIMUMHP;
            }
            PlayerPrefs.SetInt("Number of Lives", FriendController.hp1); // 味方機体1のHPを保存
            PlayerPrefs.SetInt("Number of Lives", FriendController2.hp2); // 味方機体2のHPを保存
            insufficientCoinsText.gameObject.SetActive(false); // コインが足りている場合は非表示
            insufficientCoinsObject.SetActive(false); // コインが足りている場合は非表示
            purchaseCount++; // 購入回数を増やす
            PlayerPrefs.SetInt("Number of Life Purchases", purchaseCount); // 購入回数を保存
            UpdateCostText(); // 値段を更新
        }
        else if (FriendController.hp1 >= MAXIMUMHP)//味方機体HPが3f以上3fなら中の処理を実行
        {
            if (lackofcoins != null)
            {
                lackofcoins.Play();//買えなかった時に鳴らす
            }
            insufficientCoinsText.text = "HPは最大です"; // 上限に達したメッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
        else
        {
            if (lackofcoins != null)
            {
                lackofcoins.Play();//買えなかった時に鳴らす
            }
            insufficientCoinsText.text = "コインが足りません"; // メッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
    }

    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * PRESENT); // 現在のコイン消費量を計算
        costText.text = "×" + currentCost.ToString() + ""; // 値段を表示
    }


    //ボタンの上にマウスポインタが重なったら中の処理を実行
    public void OnMouseEnter()
    {
        if (firstButton == false)
        {
            buttonAudio.Play();
            firstButton = true;
        }
    }
    
    //ボタンの上にマウスポインタが重なっていない時中の処理を実行
    public void OnMouseExit()
    {
        firstButton = false;
    }

}
