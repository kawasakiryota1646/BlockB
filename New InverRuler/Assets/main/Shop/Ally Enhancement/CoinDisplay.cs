using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン名を取得するために必要

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    public Transform coinTarget; // コインの目的地

    private void Update()
    {
        coinText.text = CoinManager.coinCount.ToString();
    }
    
    



 
}

