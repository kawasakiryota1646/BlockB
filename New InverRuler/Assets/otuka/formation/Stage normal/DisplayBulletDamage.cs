using UnityEngine;
using UnityEngine.UI;

public class DisplayBulletDamage : MonoBehaviour
{
    public Text damageText;

    void Start()
    {
        UpdateDamageText();
    }

    void UpdateDamageText()
    {
        damageText.text = "�e�̈З�: " + AttckBullet.damage.ToString();
    }

    void Update()
    {
        // ��ɍŐV�̃_���[�W�l��\������ꍇ
        UpdateDamageText();
    }
}
