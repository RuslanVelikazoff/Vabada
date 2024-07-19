using System;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public static ShopData Instance;

    public int[] _improveLevel;
    public bool[] _buyAbilities;
    public bool[] _buyCosmetic;

    private const string SaveKey = "MainSaveShop";

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

        _improveLevel = data.improveLevel;
        _buyAbilities = data.buyAbilities;
        _buyCosmetic = data.buyCosmetic;
        
        Debug.Log("Shop data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Shop data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            improveLevel = _improveLevel,
            buyAbilities = _buyAbilities,
            buyCosmetic = _buyCosmetic
        };

        return data;
    }

    #region Cosmetic
    
    public bool IsBuyCosmetic(int index)
    {
        return _buyCosmetic[index];
    }

    public void BuyCosmetic(int index)
    {
        _buyCosmetic[index] = true;
        Save();
    }
    
    #endregion


    #region Abilities
    
    public bool IsBuyAbilities(int index)
    {
        return _buyAbilities[index];
    }

    public void BuyAbilities(int index)
    {
        _buyAbilities[index] = true;
        Save();
    }
    
    #endregion

    #region Improve

    public int GetImproveLevel(int index)
    {
        return _improveLevel[index];
    }

    public void BuyImprove(int index)
    {
        _improveLevel[index]++;
        Save();
    }

    #endregion
}
