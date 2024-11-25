using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coinCount = 0; // ‰Šú’l‚ğ0‚Éİ’è

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

    public void AddCoins(int amount)
    {
        coinCount += amount;
    }

    public void RemoveCoins(int amount)
    {
        coinCount -= amount;
    }
}

