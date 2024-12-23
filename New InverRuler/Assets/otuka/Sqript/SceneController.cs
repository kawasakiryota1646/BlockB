using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに必要
using UnityEngine.EventSystems; // マウスイベントに必要

public class SceneController : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
    public PlayerController playerController;// PlayerControllerを呼び出す
    public FriendController friendController;// FriendControllerを呼び出す
    public FriendController2 friendController2;// FriendController2を呼び出す
    public AudioSource BGM; // SEを再生するAudioSource
    public AudioSource click;//ボタンを押したときに再生するAudioSource
    public AudioSource Button_Audio;//マウスが上に乗った時に再生するAudioSource
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
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2秒後にシーンを変更
      
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
        //それぞれのHPを元に戻す
        friendController.ResetHealth();
        friendController2.ResetHealth2();
        playerController.ResetPlayerHealth();
        

       
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
