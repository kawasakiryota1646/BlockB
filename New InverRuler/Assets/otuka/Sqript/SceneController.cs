using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems; // �}�E�X�C�x���g�ɕK�v

public class SceneController : MonoBehaviour
{
    public string sceneName; //�ǂݍ��ރV�[����
    public PlayerController playerController;
    public FriendController friendController;
    public FriendController2 friendController2;
    public AudioSource BGM; // SE���Đ����邽�߂�AudioSource
    public AudioSource click;
    public AudioSource Button_Audio;
    bool first_Button = false;
    private void Start()
    {
        if (BGM != null)
        {
            BGM.Play();
        }
    }
    public void Load()
    {
        if (BGM != null)
        {
            BGM.Stop();
        }


       
        if (click != null)
        {
            click.Play();
        }
        ResetCurrentScene();
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2�b��ɃV�[����ύX
      
    }
    public void OnPointerEnter()
    {

        if (first_Button == false)
        {
            Button_Audio.Play();
            first_Button = true;
        }
    }

    void ResetCurrentScene()
    {
        friendController.ResetHealth();
        friendController2.ResetHealth2();
        playerController.ResetPlayerHealth();
        

        // ���̃��Z�b�g�����������ɒǉ�
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void OnMouseExit()
    {
        first_Button = false;
    }
}
