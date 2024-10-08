using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance;
    
    private bool[] _openLocation;

    private bool[] _openForestLevel;
    private bool[] _openCastleLevel;
    private bool[] _openDesertLevel;
    private bool[] _openSubseaLevel;
    
    private const string SaveKey = "MainSaveLevel";

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

        _openLocation = data.openLocation;
        _openForestLevel = data.openForestLevel;
        _openCastleLevel = data.openCastleLevel;
        _openDesertLevel = data.openDesertLevel;
        _openSubseaLevel = data.openSubseaLevel;
        
        Debug.Log("Level data loaded");
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
            openLocation = _openLocation,
            openForestLevel = _openForestLevel,
            openCastleLevel = _openCastleLevel,
            openDesertLevel = _openDesertLevel,
            openSubseaLevel = _openSubseaLevel
        };

        return data;
    }

    #region Location

    public bool IsOpenLocation(int index)
    {
        return _openLocation[index];
    }

    public void UnlockLocation(int index)
    {
        _openLocation[index] = true;
    }

    #endregion

    #region Forest

    public bool IsOpenForestLevel(int index)
    {
        return _openForestLevel[index];
    }

    public void UnlockForestLevel(int index)
    {
        _openForestLevel[index] = true;
    }

    #endregion

    #region Castle

    public bool IsOpenCastleLevel(int index)
    {
        return _openCastleLevel[index];
    }

    public void UnlockCastleLevel(int index)
    {
        _openCastleLevel[index] = true;
    }

    #endregion

    #region Desert

    public bool IsOpenDesertLevel(int index)
    {
        return _openDesertLevel[index];
    }

    public void UnlockDesertLevel(int index)
    {
        _openDesertLevel[index] = true;
    }

    #endregion

    #region Subsea

    public bool IsOpenSubseaLevel(int index)
    {
        return _openSubseaLevel[index];
    }

    public void UnlockSubseaLevel(int index)
    {
        _openSubseaLevel[index] = true;
    }

    #endregion
}
