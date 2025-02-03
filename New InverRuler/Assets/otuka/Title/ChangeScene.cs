using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに必要
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // マウスイベントに必要

/// <summary>
/// シーンの移動を管理するスクリプト
/// </summary>
public class ChangeScene : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
    public AudioSource BGM; // SEを再生するためのAudioSource
    public AudioSource click; // SEを再生するためのAudioSource
    public AudioSource Button_Audio;
    bool first_Button = false;
    // Start is called before the first frame update
    void Start()
    {
       
        if (BGM != null)
        {
            BGM.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //シーンを読み込む
    public void Load()
    {
        //if (BGM != null)
        //{
        //    BGM.Stop();
        //}

        if (click != null)
        {
            click.Play();
        }
        StartCoroutine(ChangeSceneAfterDelay(0.3f)); // 2秒後にシーンを変更
    }
  
    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void OnMouseEnter()
    {
        if(first_Button == false)
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