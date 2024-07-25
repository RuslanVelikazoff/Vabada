using UnityEngine;
using UnityEngine.UI;

public enum LevelName
{
    ForestLevel,
    CastleLevel,
    DesertLevel,
    SubseaLevel
}

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButton;

    [SerializeField] 
    private Sprite unlockLevelSprite;
    [SerializeField] 
    private Sprite lockLevelSprite;

    [SerializeField]
    private LevelName LEVEL_NAME;

    private bool[] levelUnlock;

    private void OnEnable()
    {
        levelUnlock = new bool[levelButton.Length];
        SetLevelUnlock();
        SetButtonSprite();
        ButtonFunctions();
    }

    private void ButtonFunctions()
    {
        if (levelButton[0] != null)
        {
            levelButton[0].onClick.RemoveAllListeners();
            levelButton[0].onClick.AddListener(() =>
            {
                if (levelUnlock[0])
                {
                    Loader.Load(LEVEL_NAME + 0.ToString());
                }
            });
        }
        
        if (levelButton[1] != null)
        {
            levelButton[1].onClick.RemoveAllListeners();
            levelButton[1].onClick.AddListener(() =>
            {
                if (levelUnlock[1])
                {
                    Loader.Load(LEVEL_NAME + 1.ToString());
                }
            });
        }
        
        if (levelButton[2] != null)
        {
            levelButton[2].onClick.RemoveAllListeners();
            levelButton[2].onClick.AddListener(() =>
            {
                if (levelUnlock[2])
                {
                    Loader.Load(LEVEL_NAME + 2.ToString());
                }
            });
        }
        
        if (levelButton[3] != null)
        {
            levelButton[3].onClick.RemoveAllListeners();
            levelButton[3].onClick.AddListener(() =>
            {
                if (levelUnlock[3])
                {
                    Loader.Load(LEVEL_NAME + 3.ToString());
                }
            });
        }
        
        if (levelButton[4] != null)
        {
            levelButton[4].onClick.RemoveAllListeners();
            levelButton[4].onClick.AddListener(() =>
            {
                if (levelUnlock[4])
                {
                    Loader.Load(LEVEL_NAME + 4.ToString());
                }
            });
        }
        
        if (levelButton[5] != null)
        {
            levelButton[5].onClick.RemoveAllListeners();
            levelButton[5].onClick.AddListener(() =>
            {
                if (levelUnlock[5])
                {
                    Loader.Load(LEVEL_NAME + 5.ToString());
                }
            });
        }
        
        if (levelButton[6] != null)
        {
            levelButton[6].onClick.RemoveAllListeners();
            levelButton[6].onClick.AddListener(() =>
            {
                if (levelUnlock[6])
                {
                    Loader.Load(LEVEL_NAME + 6.ToString());
                }
            });
        }
        
        if (levelButton[7] != null)
        {
            levelButton[7].onClick.RemoveAllListeners();
            levelButton[7].onClick.AddListener(() =>
            {
                if (levelUnlock[7])
                {
                    Loader.Load(LEVEL_NAME + 7.ToString());
                }
            });
        }
    }

    private void SetButtonSprite()
    {
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (levelUnlock[i])
            {
                levelButton[i].GetComponent<Image>().sprite = unlockLevelSprite;
            }
            else
            {
                levelButton[i].GetComponent<Image>().sprite = lockLevelSprite;
            }
        }
    }

    private void SetLevelUnlock()
    {
        switch (LEVEL_NAME)
        {
            case LevelName.ForestLevel:
                for (int i = 0; i < levelButton.Length; i++)
                {
                    levelUnlock[i] = LevelData.Instance.IsOpenForestLevel(i);
                }
                break;
            case LevelName.CastleLevel:
                for (int i = 0; i < levelButton.Length; i++)
                {
                    levelUnlock[i] = LevelData.Instance.IsOpenCastleLevel(i);
                }
                break;
            case LevelName.DesertLevel:
                for (int i = 0; i < levelButton.Length; i++)
                {
                    levelUnlock[i] = LevelData.Instance.IsOpenDesertLevel(i);
                }
                break;
            case LevelName.SubseaLevel:
                for (int i = 0; i < levelButton.Length; i++)
                {
                    levelUnlock[i] = LevelData.Instance.IsOpenSubseaLevel(i);
                }
                break;
        }
    }
}
