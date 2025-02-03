using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����@�̂�HP���w�����邽�߂̃X�N���v�g
/// </summary>
public class friendlyHP : MonoBehaviour
{
    public AudioSource buttonAudio;//�{�^���̏�Ƀ}�E�X�|�C���^�������特��炷Audio
    bool firstButton = false;//
    public Button changeHP;//HP��ύX����{�^��
    public AudioSource coinAudioSource; // �_���[�W���ʉ��p
    public Text insufficientCoinsText; // �R�C���s�����b�Z�[�W�p
    public GameObject insufficientCoinsObject; // �R�C���s�����ɕ\������I�u�W�F�N�g
    public Text costText; // �l�i�\���p��Text�R���|�[�l���g
    private int purchaseCount; // �w���񐔂��Ǘ�����ϐ�
    private int baseCost = 50; // ��{�̃R�C�������
    public AudioSource lackofcoins;//�����Ȃ��������ɖ炷SE
    const int MAXIMUMHP = 3;//�ő�HP��萔��
    const int PRESENT = 10;//�ŏ��̕K�v�ȃR�C���̖�����萔��
    const int INCREASE = 1;//��������HP�̒l��萔��
    public GameObject Buy2;
    public GameObject Soldout2;
    //�X�^�[�g�֐�
    void Start()
    {

        purchaseCount = PlayerPrefs.GetInt("Number of Life Purchases", 0); // �ۑ����ꂽ�w���񐔂�ǂݍ���
        FriendController.hp1 = PlayerPrefs.GetInt("Number of Lives", 1); // �ۑ����ꂽ�����@��1HP��ǂݍ���
        FriendController2.hp2 = PlayerPrefs.GetInt("Number of Lives", 1); // �ۑ����ꂽ�����@��2HP��ǂݍ���
        changeHP.onClick.AddListener(ChangeHP);//�{�^������������HP�𑝂₷�֐��Ɉړ�����
        insufficientCoinsText.gameObject.SetActive(false); // ������Ԃł͔�\��
        insufficientCoinsObject.SetActive(false); // ������Ԃł͔�\��
        Soldout2.SetActive(false);
        Buy2.SetActive(true);
        UpdateCostText(); // �����l��\��
    }
    /// <summary>
    /// �����@�̂�HP�𑝂₷�֐�
    /// </summary>
    //�`�F���W�֐�
    void ChangeHP()
    {
        int currentCost = baseCost + (purchaseCount * PRESENT); // ���݂̃R�C������ʂ��v�Z

        if (CoinManager.coinCount >= currentCost && FriendController.hp1 < MAXIMUMHP)//�R�C���̖������l�i��荂���@HP��3�ȉ��Ȃ璆�̏��������s
        {
            // �_���[�W���ʉ����Đ�
            if (coinAudioSource != null)
            {
                coinAudioSource.Play();
            }
            CoinManager.instance.RemoveCoins(currentCost);//CoinManager���擾

            FriendController.hp1 += INCREASE; // �����@��1HP��+1����
            FriendController2.hp2 += INCREASE;//�����@��2HP��+1����

            if (FriendController.hp1 > MAXIMUMHP)//�����@��1HP��3f�ȏ�ɂȂ�Ȃ�3f�ɒ���
            {
               FriendController.hp1 = MAXIMUMHP; 
            }

            if (FriendController2.hp2 > MAXIMUMHP)//�����@��2HP��3f�ȏ�ɂȂ�Ȃ�3f�ɒ���
            {
                FriendController2.hp2 = MAXIMUMHP;
            }
            PlayerPrefs.SetInt("Number of Lives", FriendController.hp1); // �����@��1��HP��ۑ�
            PlayerPrefs.SetInt("Number of Lives", FriendController2.hp2); // �����@��2��HP��ۑ�
            insufficientCoinsText.gameObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            insufficientCoinsObject.SetActive(false); // �R�C��������Ă���ꍇ�͔�\��
            purchaseCount++; // �w���񐔂𑝂₷
            PlayerPrefs.SetInt("Number of Life Purchases", purchaseCount); // �w���񐔂�ۑ�
            UpdateCostText(); // �l�i���X�V
        }
        else if (FriendController.hp1 >= MAXIMUMHP)//�����@��HP��3f�ȏ�3f�Ȃ璆�̏��������s
        {
            if (lackofcoins != null)
            {
                lackofcoins.Play();//�����Ȃ��������ɖ炷
            }
            insufficientCoinsText.text = "HP�͍ő�ł�"; // ����ɒB�������b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
            Buy2.SetActive(false);
            Soldout2.SetActive(true);
        }
        else
        {
            if (lackofcoins != null)
            {
                lackofcoins.Play();//�����Ȃ��������ɖ炷
            }
            insufficientCoinsText.text = "�R�C��������܂���"; // ���b�Z�[�W��ݒ�
            insufficientCoinsText.gameObject.SetActive(true); // ���b�Z�[�W��\��
            insufficientCoinsObject.SetActive(true); // �I�u�W�F�N�g��\��
        }
    }
    /// <summary>
    /// HP�𑝂₷�ׂɕK�v�ȃR�C���̖�����\������֐�
    /// </summary>
    void UpdateCostText()
    {
        int currentCost = baseCost + (purchaseCount * PRESENT); // ���݂̃R�C������ʂ��v�Z
        costText.text = "�~" + currentCost.ToString() + ""; // �l�i��\��
    }


    //�{�^���̏�Ƀ}�E�X�|�C���^���d�Ȃ����璆�̏��������s
    public void OnMouseEnter()
    {
        if (firstButton == false)
        {
            buttonAudio.Play();
            firstButton = true;
        }
    }
    
    //�{�^���̏�Ƀ}�E�X�|�C���^���d�Ȃ��Ă��Ȃ������̏��������s
    public void OnMouseExit()
    {
        firstButton = false;
    }

}
