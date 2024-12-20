using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public static int coinCount = 0; // 初期値を0に設定

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCoins();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        SaveCoins();
    }

    public void RemoveCoins(int amount)
    {
        coinCount -= amount;
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
    }

    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        else
        {
            coinCount = 0;
        }
    }
}

