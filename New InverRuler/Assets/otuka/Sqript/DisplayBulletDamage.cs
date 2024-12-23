using UnityEngine;
using UnityEngine.UI;

public class DisplayBulletDamage : MonoBehaviour
{
    public Text damageText;//自機(プレイヤー)の弾の威力を表示するテキスト

    void Start()
    {
        UpdateDamageText();
    }

    void UpdateDamageText()
    {
        damageText.text = "弾の威力: " + PlayerPrefs.GetFloat("AttckBulletDamage", AttckBullet.damage).ToString();
        //保存された自機(プレイヤー)の弾を読み込み
    }

    void Update()
    {
        // 常に最新のダメージ値を表示する場合
        UpdateDamageText();
    }
}
