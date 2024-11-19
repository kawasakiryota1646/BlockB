using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button buttonToShow1; // 表示する最初のボタン
    public Button buttonToShow2; // 表示する2つ目のボタン
    public Button triggerButton; // 表示をトリガーするボタン
    private bool buttonsVisible = false; // ボタンの表示状態を追跡するフラグ

    void Start()
    {
        buttonToShow1.gameObject.SetActive(false); // 最初は非表示にする
        buttonToShow2.gameObject.SetActive(false); // 最初は非表示にする
    }

    public void OnTriggerButtonClick()
    {
        buttonsVisible = !buttonsVisible; // フラグを反転させる

        buttonToShow1.gameObject.SetActive(buttonsVisible); // ボタンの表示状態を切り替える
        buttonToShow2.gameObject.SetActive(buttonsVisible); // ボタンの表示状態を切り替える
    }
}

