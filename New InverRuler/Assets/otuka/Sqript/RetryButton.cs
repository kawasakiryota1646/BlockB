using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems; // �}�E�X�C�x���g�ɕK�v
public class RetryButton : MonoBehaviour
{
    public PlayerController playerController;// PlayerController���Ăяo��
    public FriendController friendController;// FriendController���Ăяo��
    public FriendController2 friendController2;// FriendController2���Ăяo��
    public AudioSource click;//�{�^�����N���b�N�������ɍĐ�����AudioSource
    public AudioSource BGM; // SE���Đ����邽�߂�AudioSource
    public AudioSource Button_Audio;//�{�^���̏�Ƀ}�E�X�|�C���^���������ɍĐ�����AudioSource
    bool first_Button = false;
    private void Start()
    {
        if (BGM != null)
        {
            BGM.Play();
        }
    }
    public void Retry()
    {
        if (BGM != null)
        {
            BGM.Stop();
        }


       
        if (click != null)
        {
            click.Play();
        }
        // ���ꂼ��̃��C�t�������l�ɖ߂�
        playerController.ResetPlayerHealth();
        friendController.ResetHealth();
        friendController2.ResetHealth2();

        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2�b��ɃV�[����ύX
    }
    public void OnMouseEnter()
    {
        if (first_Button == false)
        {
            Button_Audio.Play();
            first_Button = true;
        }
    }
    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // ���݂̃V�[�����ēǂݍ��݂���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnMouseExit()
    {
        first_Button = false;
    }
}




