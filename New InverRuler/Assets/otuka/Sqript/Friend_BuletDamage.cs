using UnityEngine;
using UnityEngine.UI;

public class Friend_BuletDamage : MonoBehaviour
{
    public Text damageText;//�t�����h�̒e�̈З͂�\������text
    

    void Start()
    {
        UpdateDamageText();//Text���펞�\��
    }

    void UpdateDamageText()
    {
        damageText.text = "�e�̈З�: " + PlayerPrefs.GetFloat("BulletFriendDamage", FriendBullet_Damage.damage).ToString();
        //�ۑ����ꂽ�����@�̂̒e��ǂݍ���
        
    }

    void Update()
    {
        // ��ɍŐV�̃_���[�W�l��\������ꍇ
        UpdateDamageText();
    }
}