using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 味方機体の弾の威力を表示するスクリプト
/// </summary>
public class Friend_BuletDamage : MonoBehaviour
{
    public Text damageText;//フレンドの弾の威力を表示するtext
    

    void Start()
    {
        UpdateDamageText();//Textを常時表示
    }

    void UpdateDamageText()
    {
        damageText.text = ": " + PlayerPrefs.GetFloat("BulletFriendDamage", FriendBullet_Damage.damage).ToString();
        //保存された味方機体の弾を読み込み
        
    }

    void Update()
    {
        // 常に最新のダメージ値を表示する場合
        UpdateDamageText();
    }
}
