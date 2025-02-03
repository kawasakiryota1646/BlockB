using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 特定のシーンのボタンを表示、非表示にするスクリプト
/// </summary>
public class ButtonManager : MonoBehaviour
{
    public AudioSource click;
    public Button buttonToShow1; // 表示する最初のボタン
    public Button buttonToShow2; // 表示する2つ目のボタン
    public GameObject image;//表示するimageオブジェクト
    public Text text;//表示するテキスト
    public Button triggerButton; // 表示をトリガーするボタン
    private bool buttonsVisible = true; // ボタンの表示状態を追跡するフラグ
    public AudioSource Button_Audio;
    bool first_Button = false;
    void Start()
    {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        buttonToShow1.gameObject.SetActive(false); // 最初は非表示にする
        buttonToShow2.gameObject.SetActive(false); // 最初は非表示にする
    }

    public void OnTriggerButtonClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        //buttonsVisible = !buttonsVisible; // フラグを反転させる
        text.gameObject.SetActive(buttonsVisible);
        image.gameObject.SetActive(buttonsVisible);

        buttonToShow1.gameObject.SetActive(buttonsVisible); // ボタンの表示状態を切り替える
        buttonToShow2.gameObject.SetActive(buttonsVisible); // ボタンの表示状態を切り替える
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

