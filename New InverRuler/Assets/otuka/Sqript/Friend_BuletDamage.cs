using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����@�̂̒e�̈З͂�\������X�N���v�g
/// </summary>
public class Friend_BuletDamage : MonoBehaviour
{
    public Text damageText;//�t�����h�̒e�̈З͂�\������text
    

    void Start()
    {
        UpdateDamageText();//Text���펞�\��
    }

    void UpdateDamageText()
    {
        damageText.text = ": " + PlayerPrefs.GetFloat("BulletFriendDamage", FriendBullet_Damage.damage).ToString();
        //�ۑ����ꂽ�����@�̂̒e��ǂݍ���
        
    }

    void Update()
    {
        // ��ɍŐV�̃_���[�W�l��\������ꍇ
        UpdateDamageText();
    }
}
