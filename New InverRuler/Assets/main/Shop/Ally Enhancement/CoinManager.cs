using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コイン(お金)を管理するスクリプト
/// </summary>
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public static int coinCount = 0; // 現在のコイン数
    public static int previousCoinCount = 0; // 前回のコイン数

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
        PlayerPrefs.SetInt("PreviousCoinCount", previousCoinCount);
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

        if (PlayerPrefs.HasKey("PreviousCoinCount"))
        {
            previousCoinCount = PlayerPrefs.GetInt("PreviousCoinCount");
        }
        else
        {
            previousCoinCount = 0;
        }
    }

    public void UpdatePreviousCoinCount()
    {
        previousCoinCount = coinCount;
        SaveCoins();
    }
}

