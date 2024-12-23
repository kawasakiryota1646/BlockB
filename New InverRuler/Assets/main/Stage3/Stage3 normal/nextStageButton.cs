using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStageButton : MonoBehaviour
{
    public GameObject hardStageButton;

    void Start()
    {
        // ボスを倒したかどうかを確認
        if (PlayerPrefs.GetInt("BossDefeated", 0) == 1)
        {
            // ボタンを表示
            hardStageButton.SetActive(true);
        }
        else
        {
            // ボタンを非表示
            hardStageButton.SetActive(false);
        }
    }
}
