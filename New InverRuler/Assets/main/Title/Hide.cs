using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに必要
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination; // マウスイベントに必要
using UnityEngine.UI;
public class Hide : MonoBehaviour
{
    public AudioSource click; // ボタンを押した時に再生するためのAudioSource
    public GameObject image;
    public GameObject text;
    public GameObject Button1;
    public GameObject Button2;
    public AudioSource Button_Audio;////ボタンの上にマウスポインタが来た時に再生するためのAudioSource
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


        //ボタンを押したら非表示にする
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
