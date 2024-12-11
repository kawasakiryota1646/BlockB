using UnityEngine;
using UnityEngine.UI;

public class ChangeDamage : MonoBehaviour
{
    
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // ダメージ効果音用
    public Text insufficientCoinsText; // コイン不足メッセージ用
    public GameObject insufficientCoinsObject; // コイン不足時に表示するオブジェクト
    public Text costText; // 値段表示用のTextコンポーネント
    private int purchaseCount; // 購入回数を管理する変数
    private int baseCost = 20; // 基本のコイン消費量

    void Start()
    {
        purchaseCount = PlayerPrefs.GetInt("ChangeDamagePurchaseCount", 0); // 保存された購入回数を読み込む
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
        insufficientCoinsText.gameObject.SetActive(false); // 初期状態では非表示
        insufficientCoinsObject.SetActive(false); // 初期状態では非表示
        UpdateCostText(); // 初期値を表示
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 5); // 現在のコイン消費量を計算

        if (CoinManager.coinCount >= currentCost && AttckBullet.damage < 50f)
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);
            AttckBullet.damage += 5f; // ダメージを+5する
            if (AttckBullet.damage > 50f)
            {
                AttckBullet.damage = 50f; // 上限を50に設定
            }
            PlayerPrefs.SetFloat("AttckBulletDamage", AttckBullet.damage); // 弾の威力を保存
            insufficientCoinsText.gameObject.SetActive(false); // コインが足りている場合は非表示
            insufficientCoinsObject.SetActive(false); // コインが足りている場合は非表示
            purchaseCount++; // 購入回数を増やす
            PlayerPrefs.SetInt("ChangeDamagePurchaseCount", purchaseCount); // 購入回数を保存
            UpdateCostText(); // 値段を更新
        }
        else if (AttckBullet.damage >= 50f)
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
