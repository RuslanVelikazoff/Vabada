using System;
using UnityEngine;

public class CoinData : MonoBehaviour
{
    public static CoinData Instance;

    public int _coin;

    private const string SaveKey = "MainSaveCoin";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _coin = data.coin;
        
        Debug.Log("Coin data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Coin data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            coin = _coin
        };

        return data;
    }

    public int GetCoinAmount()
    {
        return _coin;
    }

    public void SubtractCoin(int amount)
    {
        _coin -= amount;
        Save();
    }

    public void AddCoin(int amount)
    {
        _coin += amount;
        Save();
    }
}
