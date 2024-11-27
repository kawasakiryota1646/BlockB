using UnityEngine;
using UnityEngine.UI;
public class BuletDamage : MonoBehaviour
{
    public Text damageText;

    void Start()
    {
        UpdateDamageText();
    }

    void UpdateDamageText()
    {
        damageText.text = "弾の威力: " + friendBULLET.damage.ToString();
    }

    void Update()
    {
        // 常に最新のダメージ値を表示する場合
        UpdateDamageText();
    }
}
