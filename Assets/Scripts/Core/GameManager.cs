using UnityEngine;

public enum Location
{
    Forest,
    Castle,
    Desert,
    Subsea
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private WinPanel winPanel;
    [SerializeField]
    private LosePanel losePanel;

    [SerializeField]
    private Location currentLocation;
    [SerializeField] 
    private int currentLevelIndex;
    [SerializeField]
    private bool unlockNewLevel;

    private void Awake()
    {
        Instance = this;
        unlockNewLevel = currentLevelIndex != 9;
        Debug.Log(unlockNewLevel);
    }

    public void Win()
    {
        winPanel.OpenPanel();
        CoinData.Instance.AddCoin(CoinManager.Instance.GetCoinAmount());

        if (unlockNewLevel)
        {
            UnlockNewLevel();
        }
        else
        {
            UnlockNewLocation();
        }
    }

    private void UnlockNewLocation()
    {
        switch (currentLocation)
        {
            case Location.Forest:
                LevelData.Instance.UnlockLocation(1);
                break;
            case Location.Castle:
                LevelData.Instance.UnlockLocation(2);
                break;
            case Location.Desert:
                LevelData.Instance.UnlockLocation(3);
                break;
            case Location.Subsea:
                Debug.Log("Game completed");
                break;
        }
    }

    private void UnlockNewLevel()
    {
        switch (currentLocation)
        {
            case Location.Forest:
                LevelData.Instance.UnlockForestLevel(currentLevelIndex + 1);
                break;
            case Location.Castle:
                LevelData.Instance.UnlockCastleLevel(currentLevelIndex + 1);
                break;
            case Location.Desert:
                LevelData.Instance.UnlockDesertLevel(currentLevelIndex + 1);
                break;
            case Location.Subsea:
                LevelData.Instance.UnlockSubseaLevel(currentLevelIndex + 1);
                break;
        }
    }

    public void Lose()
    {
        losePanel.OpenPanel();
        CoinData.Instance.AddCoin(CoinManager.Instance.GetCoinAmount());
    }
}
