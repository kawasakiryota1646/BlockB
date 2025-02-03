using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�V�[���̐؂�ւ��ɕK�v
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // �}�E�X�C�x���g�ɕK�v
using UnityEngine.UI;
/// <summary>
/// �v���C���[�̃X�e�[�^�X�⏊�����Ă���R�C�����ŏ��̏�Ԃɖ߂��X�N���v�g
/// </summary>
public class ResetGame : MonoBehaviour
{
   
    public AudioSource click; // �{�^�������������ɍĐ����邽�߂�AudioSource
    public Button resetButton;//�������{�^��
    public CoinManager coinManager;//CoinManager���Q��
    public AudioSource Button_Audio;////�{�^���̏�Ƀ}�E�X�|�C���^���������ɍĐ����邽�߂�AudioSource
    bool first_Button = false;
    const int FRIEND_HP = 3;
    const int FRIEND_BULLET = 1;
    const int PLAYER_BULLET = 5;
    const int COIN_COUNT = 0;
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
        CoinManager.coinCount = COIN_COUNT;
        AttckBullet.damage = PLAYER_BULLET;
        FriendBullet_Damage.damage = FRIEND_BULLET;
        FriendController.hp1 = FRIEND_HP;
        FriendController2.hp2 = FRIEND_HP;
        
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
