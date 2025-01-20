using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public static int coinCount = 0; // ���݂̃R�C����
    public static int previousCoinCount = 0; // �O��̃R�C����

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

