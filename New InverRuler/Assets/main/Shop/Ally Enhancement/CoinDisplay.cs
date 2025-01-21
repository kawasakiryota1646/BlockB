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
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Ally Enhancement"||currentSceneName == "Strengthen your ship") // 特定のシーン名を指定
        {
            coinText.text = "0";
            // 特定のシーンでは増加アニメーションをスキップして合計枚数を表示

            coinText.text = CoinManager.coinCount.ToString();
        }
        else
        {
            // それ以外のシーンでは増加アニメーションを実行
            StartCoroutine(AddCoinsWithAnimation(CoinManager.previousCoinCount, CoinManager.coinCount));
        }
    }

  

    private IEnumerator AddCoinsWithAnimation(int startCoins, int endCoins)
    {
        int displayedCoins = startCoins;
        while (displayedCoins < endCoins)
        {
            displayedCoins++;
            coinText.text = displayedCoins.ToString();
            yield return new WaitForSeconds(0.09f); // アニメーションの速度を調整
        }
    }

 
}

