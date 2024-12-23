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
        damageText.text = "�e�̈З�: " + PlayerPrefs.GetFloat("BulletFriendDamage", BulletFriend.damage).ToString();

    }

    void Update()
    {
        // ��ɍŐV�̃_���[�W�l��\������ꍇ
        UpdateDamageText();
    }
}
