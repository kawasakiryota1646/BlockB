using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // �}�E�X�C�x���g�ɕK�v
using UnityEngine.UI;
public class Hide : MonoBehaviour
{
    public AudioSource click; // �{�^�������������ɍĐ����邽�߂�AudioSource
    public GameObject image;
    public GameObject text;
    public GameObject Button1;
    public GameObject Button2;
    public AudioSource Button_Audio;////�{�^���̏�Ƀ}�E�X�|�C���^���������ɍĐ����邽�߂�AudioSource
    bool first_Button = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Load()
    {
        if (click != null)
        {
            click.Play();
        }


        //�{�^�������������\���ɂ���
        image.SetActive(false);
        Button1.SetActive(false);
        text.SetActive(false);
        Button2.SetActive(false);
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
