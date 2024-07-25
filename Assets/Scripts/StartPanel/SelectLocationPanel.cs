using UnityEngine;
using UnityEngine.UI;

public class SelectLocationPanel : MonoBehaviour
{
    [SerializeField] 
    private Button[] locationButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject[] levelPanel;

    [Space(13)]
    
    [SerializeField]
    private Sprite[] openLocationSprite;
    [SerializeField]
    private Sprite[] closeLocationSprite;

    private void OnEnable()
    {
        SetButtonSprite();
        ButtonFunctions();
    }

    private void SetButtonSprite()
    {
        for (int i = 0; i < locationButton.Length; i++)
        {
            if (LevelData.Instance.IsOpenLocation(i))
            {
                locationButton[i].GetComponent<Image>().sprite = openLocationSprite[i];
            }
            else
            {
                locationButton[i].GetComponent<Image>().sprite = closeLocationSprite[i];
            }
        }
    }

    private void ButtonFunctions()
    {
        if (locationButton[0] != null)
        {
            locationButton[0].onClick.RemoveAllListeners();
            locationButton[0].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsOpenLocation(0))
                {
                    this.gameObject.SetActive(false);
                    levelPanel[0].SetActive(true);
                }
            });
        }
        
        if (locationButton[1] != null)
        {
            locationButton[1].onClick.RemoveAllListeners();
            locationButton[1].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsOpenLocation(1))
                {
                    this.gameObject.SetActive(false);
                    levelPanel[1].SetActive(true);
                }
            });
        }
        
        if (locationButton[2] != null)
        {
            locationButton[2].onClick.RemoveAllListeners();
            locationButton[2].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsOpenLocation(2))
                {
                    this.gameObject.SetActive(false);
                    levelPanel[2].SetActive(true);
                }
            });
        }
        
        if (locationButton[3] != null)
        {
            locationButton[3].onClick.RemoveAllListeners();
            locationButton[3].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsOpenLocation(3))
                {
                    this.gameObject.SetActive(false);
                    levelPanel[3].SetActive(true);
                }
            });
        }
    }
}
