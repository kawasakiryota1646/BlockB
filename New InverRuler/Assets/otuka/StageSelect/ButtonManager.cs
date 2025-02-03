using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����̃V�[���̃{�^����\���A��\���ɂ���X�N���v�g
/// </summary>
public class ButtonManager : MonoBehaviour
{
    public AudioSource click;
    public Button buttonToShow1; // �\������ŏ��̃{�^��
    public Button buttonToShow2; // �\������2�ڂ̃{�^��
    public GameObject image;//�\������image�I�u�W�F�N�g
    public Text text;//�\������e�L�X�g
    public Button triggerButton; // �\�����g���K�[����{�^��
    private bool buttonsVisible = true; // �{�^���̕\����Ԃ�ǐՂ���t���O
    public AudioSource Button_Audio;
    bool first_Button = false;
    void Start()
    {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        buttonToShow1.gameObject.SetActive(false); // �ŏ��͔�\���ɂ���
        buttonToShow2.gameObject.SetActive(false); // �ŏ��͔�\���ɂ���
    }

    public void OnTriggerButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        //buttonsVisible = !buttonsVisible; // �t���O�𔽓]������
        text.gameObject.SetActive(buttonsVisible);
        image.gameObject.SetActive(buttonsVisible);

        buttonToShow1.gameObject.SetActive(buttonsVisible); // �{�^���̕\����Ԃ�؂�ւ���
        buttonToShow2.gameObject.SetActive(buttonsVisible); // �{�^���̕\����Ԃ�؂�ւ���
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

