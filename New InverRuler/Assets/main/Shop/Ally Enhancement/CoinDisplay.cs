using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン名を取得するために必要

/// <summary>
/// 現在所持しているコインを表示するスクリプト
/// </summary>
public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public Transform coinTarget; // コインの目的地

    private void Update()
    {
        coinText.text = CoinManager.coinCount.ToString();
    }
    
}

