using UnityEngine;
using UnityEngine.UI;

public class Bulletstrengthening : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // ダメージ効果音用
    public Text insufficientCoinsText; // コイン不足メッセージ用
    public GameObject insufficientCoinsObject; // コイン不足時に表示するオブジェクト
    public Text costText; // 値段表示用のTextコンポーネント
    private int purchaseCount; // 購入回数を管理する変数
    private int baseCost = 30; // 基本のコイン消費量

    void Start()
    {
        purchaseCount = PlayerPrefs.GetInt("BulletStrengtheningPurchaseCount", 0); // 保存された購入回数を読み込む
        BulletFriend.damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f); // 保存された弾の威力を読み込む
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
        insufficientCoinsText.gameObject.SetActive(false); // 初期状態では非表示
        insufficientCoinsObject.SetActive(false); // 初期状態では非表示
        
        UpdateCostText(); // 初期値を表示
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 5); // 現在のコイン消費量を計算

        if (CoinManager.coinCount >= currentCost && BulletFriend.damage < 5f)
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);
            BulletFriend.damage += 1f; // ダメージを+1する
            if (BulletFriend.damage > 5f)
            {
                BulletFriend.damage = 5f; // 上限を5に設定
            }
            PlayerPrefs.SetFloat("BulletFriendDamage", BulletFriend.damage); // 弾の威力を保存
            insufficientCoinsText.gameObject.SetActive(false); // コインが足りている場合は非表示
            insufficientCoinsObject.SetActive(false); // コインが足りている場合は非表示
            purchaseCount++; // 購入回数を増やす
            PlayerPrefs.SetInt("BulletStrengtheningPurchaseCount", purchaseCount); // 購入回数を保存
            UpdateCostText(); // 値段を更新
        }
        else if (BulletFriend.damage >= 5f)
        {
            insufficientCoinsText.text = "弾の威力は最大です"; // 上限に達したメッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
        else
        {
            insufficientCoinsText.text = "コインが足りません"; // メッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
    }

    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * 5); // 現在のコイン消費量を計算
        costText.text = "枚数は " + currentCost.ToString() + ""; // 値段を表示
    }
}