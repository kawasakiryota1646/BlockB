using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに必要
using UnityEngine.EventSystems; // マウスイベントに必要
public class RetryButton : MonoBehaviour
{
    public PlayerController playerController;// PlayerControllerを呼び出す
    public FriendController friendController;// FriendControllerを呼び出す
    public FriendController2 friendController2;// FriendController2を呼び出す
    public AudioSource click;//ボタンをクリックした時に再生するAudioSource
    public AudioSource BGM; // SEを再生するためのAudioSource
    public AudioSource Button_Audio;//ボタンの上にマウスポインタが来た時に再生するAudioSource
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
        // それぞれのライフを初期値に戻す
        playerController.ResetPlayerHealth();
        friendController.ResetHealth();
        friendController2.ResetHealth2();

        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2秒後にシーンを変更
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
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnMouseExit()
    {
        first_Button = false;
    }
}




