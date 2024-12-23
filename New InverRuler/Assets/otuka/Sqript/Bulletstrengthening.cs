using UnityEngine;
using UnityEngine.UI;

public class Bulletstrengthening : MonoBehaviour
{

    public AudioSource Button_Audio;//ボタンの上にマウスポインタが乗った時に再生するAudioSource
    bool first_Button = false;
    public Button changeDamageButton;//味方機体の弾を強化するボタン
    public AudioSource CoinAudioSource; // ダメージ効果音用
    public Text insufficientCoinsText; // コイン不足メッセージ用
    public GameObject insufficientCoinsObject; // コイン不足時に表示するオブジェクト
    public Text costText; // 値段表示用のTextコンポーネント
    private int purchaseCount; // 購入回数を管理する変数
    private int baseCost = 30; // 基本のコイン消費量
 
    void Start()
    {
        
        purchaseCount = PlayerPrefs.GetInt("BulletStrengtheningPurchaseCount", 0); // 保存された購入回数を読み込む
        FriendBullet_Damage.damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f); // 保存された弾の威力を読み込む
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);//ボタンがクリックされたらChangeBulletDamageの関数に飛ぶ
        insufficientCoinsText.gameObject.SetActive(false); // 初期状態では非表示
        insufficientCoinsObject.SetActive(false); // 初期状態では非表示
        
        UpdateCostText(); // 初期値を表示
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 5); // 現在のコイン消費量を計算

        if (CoinManager.coinCount >= currentCost && FriendBullet_Damage.damage < 3f)//コインの枚数が値段より高く　弾の威力が3f以下なら中の処理を実行
        {
            // ダメージ効果音を再生
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);

            FriendBullet_Damage.damage += 1f; // ダメージを+1する
            if (FriendBullet_Damage.damage > 3f)
            {
                FriendBullet_Damage.damage = 3f; // 上限を3に設定
            }
            PlayerPrefs.SetFloat("BulletFriendDamage", FriendBullet_Damage.damage); // 弾の威力を保存
            
            insufficientCoinsText.gameObject.SetActive(false); // コインが足りている場合は非表示
            insufficientCoinsObject.SetActive(false); // コインが足りている場合は非表示
            purchaseCount++; // 購入回数を増やす
            PlayerPrefs.SetInt("BulletStrengtheningPurchaseCount", purchaseCount); // 購入回数を保存
            UpdateCostText(); // 値段を更新
        }
        else if (FriendBullet_Damage.damage >= 3f)//味方機体の弾の威力が最大なら中の処理を実行
        {

            insufficientCoinsText.text = "弾の威力は最大です"; // 上限に達したメッセージを設定
            insufficientCoinsText.gameObject.SetActive(true); // メッセージを表示
            insufficientCoinsObject.SetActive(true); // オブジェクトを表示
        }
        else//どれも当てはまらないなら中の処理を実行
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