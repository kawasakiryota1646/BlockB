using UnityEngine;
using UnityEngine.UI;

public class DisplayBulletDamage : MonoBehaviour
{
    public Text damageText;//���@(�v���C���[)�̒e�̈З͂�\������e�L�X�g

    void Start()
    {
        UpdateDamageText();
    }

    void UpdateDamageText()
    {
        damageText.text = "�e�̈З�: " + PlayerPrefs.GetFloat("AttckBulletDamage", AttckBullet.damage).ToString();
        //�ۑ����ꂽ���@(�v���C���[)�̒e��ǂݍ���
    }

    void Update()
    {
        // ��ɍŐV�̃_���[�W�l��\������ꍇ
        UpdateDamageText();
    }
}
