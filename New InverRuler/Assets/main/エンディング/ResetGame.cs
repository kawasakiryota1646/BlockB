using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // �}�E�X�C�x���g�ɕK�v
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
   
    public AudioSource click; // �{�^�������������ɍĐ����邽�߂�AudioSource
    public Button resetButton;//�������{�^��
    public CoinManager coinManager;//CoinManager���Q��
    public AudioSource Button_Audio;////�{�^���̏�Ƀ}�E�X�|�C���^���������ɍĐ����邽�߂�AudioSource
    bool first_Button = false;
    void Start()
    {
        resetButton.onClick.AddListener(ResetAllScenes);//resetButton����������ResetAllScenes�֐��Ɉړ�
    }

    void ResetAllScenes()
    {
       
        if (click != null)
        {
            click.Play();
        }


        Resett();//Resett�֐��Ɉړ�
        
        // PlayerPrefs�̃f�[�^��S�č폜
        PlayerPrefs.DeleteAll();

        // �K�v�ɉ����āA����̏�����������ǉ�
        // ��: �����V�[���ɖ߂�
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2�b��ɃV�[����ύX
       
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");//�^�C�g���Ɉړ�
    }
    public void Resett()
    {
        // �{�X��|�������Ƃ��L�^
        PlayerPrefs.SetInt("BossDefeated", 0);
        //���ꂼ��̐��l������������
        CoinManager.coinCount = 0;
        AttckBullet.damage = 5;
        FriendBullet_Damage.damage = 1;
        FriendController.hp1 = 1;
        FriendController2.hp2 = 1;
        
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
