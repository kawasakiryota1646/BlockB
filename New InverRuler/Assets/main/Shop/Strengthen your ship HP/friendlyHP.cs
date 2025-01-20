using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class friendlyHP : MonoBehaviour
{
    public AudioSource Button_Audio;
    bool first_Button = false;
    public Button changeDamageButton;
    public AudioSource CoinAudioSource; // �_���[�W���ʉ��p
    public Text insufficientCoinsText; // �R�C���s�����b�Z�[�W�p
    public GameObject insufficientCoinsObject; // �R�C���s�����ɕ\������I�u�W�F�N�g
    public Text costText; // �l�i�\���p��Text�R���|�[�l���g
    private int purchaseCount; // �w���񐔂��Ǘ�����ϐ�
    private int baseCost = 50; // ��{�̃R�C�������
    public AudioSource Lackofcoins;//�����Ȃ��������ɖ炷SE
    void Start()
    {

        purchaseCount = PlayerPrefs.GetInt("Number of Life Purchases", 0); // �ۑ����ꂽ�w���񐔂�ǂݍ���
        FriendController.hp1 = PlayerPrefs.GetInt("Number of Lives", 1); // �ۑ����ꂽHP�̈З͂�ǂݍ���
        FriendController2.hp2 = PlayerPrefs.GetInt("Number of Lives", 1); // �ۑ����ꂽHP�̈З͂�ǂݍ���
        changeDamageButton.onClick.AddListener(ChangeBulletDamage);
        insufficientCoinsText.gameObject.SetActive(false); // ������Ԃł͔�\��
        insufficientCoinsObject.SetActive(false); // ������Ԃł͔�\��

        UpdateCostText(); // �����l��\��
    }

    void ChangeBulletDamage()
    {
        int currentCost = baseCost + (purchaseCount * 10); // ���݂̃R�C������ʂ��v�Z

        if (CoinManager.coinCount >= currentCost && FriendController.hp1 < 3f)
        {
            // �_���[�W���ʉ����Đ�
            if (CoinAudioSource != null)
            {
                CoinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);

            FriendController.hp1 += 1; // �_���[�W��+1����
            FriendController2.hp2 += 1;
            if (FriendController.hp1 > 3f)
            {
               FriendController.hp1 = 3; // �����5�ɐݒ�
            }
            if (FriendController2.hp2 > 3f)
            {
                FriendController2.hp2 = 3; // �����5�ɐݒ�
            }
            PlayerPrefs.SetInt("Number of Lives", FriendController.hp1); // �e�̈З͂�ۑ�
            PlayerPrefs.SetInt("Number of Lives", FriendController2.hp2); // �e�̈З͂�ۑ�
            insufficientCoinsText.gameObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            insufficientCoinsObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            purchaseCount++; // �w���񐔂𑝂₷
            PlayerPrefs.SetInt("Number of Life Purchases", purchaseCount); // �w���񐔂�ۑ�
            UpdateCostText(); // �l�i���X�V
        }
        else if (FriendController.hp1 >= 3)
        {
            if (Lackofcoins != null)
            {
                Lackofcoins.Play();//�����Ȃ��������ɖ炷
            }
            insufficientCoinsText.text = "HP�͍ő�ł�"; // ����ɒB�������b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
        }
        else
        {
            if (Lackofcoins != null)
            {
                Lackofcoins.Play();//�����Ȃ��������ɖ炷
            }
            insufficientCoinsText.text = "�R�C��������܂���"; // ���b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
        }
    }

    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * 10); // ���݂̃R�C������ʂ��v�Z
        costText.text = "�~" + currentCost.ToString() + ""; // �l�i��\��
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
