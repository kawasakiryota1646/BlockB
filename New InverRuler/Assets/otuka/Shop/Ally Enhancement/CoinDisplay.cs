using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;

    private void Update()
    {
        coinText.text = "�R�C��:" + CoinManager.instance.coinCount.ToString();
    }
}

