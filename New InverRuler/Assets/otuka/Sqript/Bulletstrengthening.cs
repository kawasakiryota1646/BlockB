using UnityEngine;
using UnityEngine.UI;

public class Bulletstrengthening : MonoBehaviour
{
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // �_���[�W���ʉ��p
    public Text insufficientCoinsText; // �R�C���s�����b�Z�[�W�p
    public GameObject insufficientCoinsObject; // �R�C���s�����ɕ\������I�u�W�F�N�g
    public Text costText; // �l�i�\���p��Text�R���|�[�l���g
    private int purchaseCount; // �w���񐔂��Ǘ�����ϐ�
    private int baseCost = 30; // ��{�̃R�C�������

    void Start()
    {
        purchaseCount = PlayerPrefs.GetInt("BulletStrengtheningPurchaseCount", 0); // �ۑ����ꂽ�w���񐔂�ǂݍ���
        BulletFriend.damage = PlayerPrefs.GetFloat("BulletFriendDamage", 1f); // �ۑ����ꂽ�e�̈З͂�ǂݍ���
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
        insufficientCoinsText.gameObject.SetActive(false); // ������Ԃł͔�\��
        insufficientCoinsObject.SetActive(false); // ������Ԃł͔�\��
        
        UpdateCostText(); // �����l��\��
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 5); // ���݂̃R�C������ʂ��v�Z

        if (CoinManager.coinCount >= currentCost && BulletFriend.damage < 5f)
        {
            // �_���[�W���ʉ����Đ�
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);
            BulletFriend.damage += 1f; // �_���[�W��+1����
            if (BulletFriend.damage > 5f)
            {
                BulletFriend.damage = 5f; // �����5�ɐݒ�
            }
            PlayerPrefs.SetFloat("BulletFriendDamage", BulletFriend.damage); // �e�̈З͂�ۑ�
            insufficientCoinsText.gameObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            insufficientCoinsObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            purchaseCount++; // �w���񐔂𑝂₷
            PlayerPrefs.SetInt("BulletStrengtheningPurchaseCount", purchaseCount); // �w���񐔂�ۑ�
            UpdateCostText(); // �l�i���X�V
        }
        else if (BulletFriend.damage >= 5f)
        {
            insufficientCoinsText.text = "�e�̈З͍͂ő�ł�"; // ����ɒB�������b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
        }
        else
        {
            insufficientCoinsText.text = "�R�C��������܂���"; // ���b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
        }
    }

    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * 5); // ���݂̃R�C������ʂ��v�Z
        costText.text = "������ " + currentCost.ToString() + ""; // �l�i��\��
    }
}