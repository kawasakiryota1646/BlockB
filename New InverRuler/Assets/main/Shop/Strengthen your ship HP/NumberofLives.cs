using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberofLives : MonoBehaviour
{
    public Text damageText;


    void Start()
    {
        UpdatelifeText();
    }

    void UpdatelifeText()
    {
        damageText.text = "HP: " + PlayerPrefs.GetInt("Number of Livess", FriendController.hp1).ToString();

    }

    void Update()
    {
        // 常に最新のダメージ値を表示する場合
        UpdatelifeText();
    }
}
