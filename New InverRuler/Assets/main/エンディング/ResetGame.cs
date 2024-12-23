using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに必要
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // マウスイベントに必要
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
   
    public AudioSource click; // SEを再生するためのAudioSource
    public Button resetButton;
    public CoinManager coinManager;
    public AudioSource Button_Audio;
    bool first_Button = false;
    void Start()
    {
        resetButton.onClick.AddListener(ResetAllScenes);
    }

    void ResetAllScenes()
    {
       
        if (click != null)
        {
            click.Play();
        }


        Resett();
        
        // PlayerPrefsのデータを全て削除
        PlayerPrefs.DeleteAll();

        // 必要に応じて、特定の初期化処理を追加
        // 例: 初期シーンに戻る
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2秒後にシーンを変更
       
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
    public void Resett()
    {
        // ボスを倒したことを記録
        PlayerPrefs.SetInt("BossDefeated", 0);
        CoinManager.coinCount = 0;
        AttckBullet.damage = 5;
        BulletFriend.damage = 1;
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
