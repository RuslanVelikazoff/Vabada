using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicPanel : MonoBehaviour
{
    [SerializeField] 
    private Button soundButton;
    [SerializeField] 
    private Button controlButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject soundPanel;
    [SerializeField] 
    private GameObject controlPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button lowButton;
    [SerializeField]
    private TextMeshProUGUI lowText;
    [SerializeField]
    private Button mediumButton;
    [SerializeField] 
    private TextMeshProUGUI mediumText;
    [SerializeField] 
    private Button highButton;
    [SerializeField] 
    private TextMeshProUGUI highText;

    [Space(13)]
    
    [SerializeField] 
    private Button resolutionButton1;
    [SerializeField] 
    private TextMeshProUGUI resolutionText1;
    [SerializeField] 
    private Button resolutionButton2;
    [SerializeField] 
    private TextMeshProUGUI resolutionText2;

    [Space(13)]
    
    [SerializeField]
    private Button resetButton;

    [Space(13)]
    
    [SerializeField] 
    private Color normalColor;
    [SerializeField] 
    private Color selectedColor;

    private const string PLAYER_PREFS_GRAPHIC = "Graphic";
    private const string LOW = "Low";
    private const string MEDIUM = "Medium";
    private const string HIGH = "High";

    private const string PLAYER_PREFS_RESOLUTION = "Resolution";
    private int selectedResolution = 0;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey(PLAYER_PREFS_GRAPHIC))
        {
            PlayerPrefs.SetString(PLAYER_PREFS_GRAPHIC, MEDIUM);
        }
        if (!PlayerPrefs.HasKey(PLAYER_PREFS_RESOLUTION))
        {
            PlayerPrefs.SetInt(PLAYER_PREFS_RESOLUTION, 0);
            selectedResolution = PlayerPrefs.GetInt(PLAYER_PREFS_RESOLUTION);
        }
        else
        {
            selectedResolution = PlayerPrefs.GetInt(PLAYER_PREFS_RESOLUTION);
        }
        
        SetGraphicButton();
        SetResolutionButton();
        ButtonFunctions();
    }

    private void ButtonFunctions()
    {
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                soundPanel.SetActive(true);
            });
        }

        if (controlButton != null)
        {
            controlButton.onClick.RemoveAllListeners();
            controlButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                controlPanel.SetActive(true);
            });
        }

        if (lowButton != null)
        {
            lowButton.onClick.RemoveAllListeners();
            lowButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString(PLAYER_PREFS_GRAPHIC, LOW);
                SetGraphicButton();
            });
        }

        if (mediumButton != null)
        {
            mediumButton.onClick.RemoveAllListeners();
            mediumButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString(PLAYER_PREFS_GRAPHIC, MEDIUM);
                SetGraphicButton();
            });
        }

        if (highButton != null)
        {
            highButton.onClick.RemoveAllListeners();
            highButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString(PLAYER_PREFS_GRAPHIC, HIGH);
                SetGraphicButton();
            });
        }

        if (resolutionButton1 != null)
        {
            resolutionButton1.onClick.RemoveAllListeners();
            resolutionButton1.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt(PLAYER_PREFS_RESOLUTION, 0);
                SetResolutionButton();
            });
        }

        if (resolutionButton2 != null)
        {
            resolutionButton2.onClick.RemoveAllListeners();
            resolutionButton2.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt(PLAYER_PREFS_RESOLUTION, 1);
                SetResolutionButton();
            });
        }

        if (resetButton != null)
        {
            resetButton.onClick.RemoveAllListeners();
            resetButton.onClick.AddListener(() =>
            {
                ResetGraphicSettings();
            });
        }
    }

    private void ResetGraphicSettings()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_GRAPHIC, MEDIUM);
        PlayerPrefs.SetInt(PLAYER_PREFS_RESOLUTION, 0);
        
        SetGraphicButton();
        SetResolutionButton();
    }

    private void SetGraphicButton()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_GRAPHIC) == LOW)
        {
            lowText.color = selectedColor;
            mediumText.color = normalColor;
            highText.color = normalColor;
        }
        
        if (PlayerPrefs.GetString(PLAYER_PREFS_GRAPHIC) == MEDIUM)
        {
            lowText.color = normalColor;
            mediumText.color = selectedColor;
            highText.color = normalColor;
        }
        
        if (PlayerPrefs.GetString(PLAYER_PREFS_GRAPHIC) == HIGH)
        {
            lowText.color = normalColor;
            mediumText.color = normalColor;
            highText.color = selectedColor;
        }
    }

    private void SetResolutionButton()
    {
        if (PlayerPrefs.GetInt(PLAYER_PREFS_RESOLUTION) == 0)
        {
            resolutionText1.color = selectedColor;
            resolutionText2.color = normalColor;
        }

        if (PlayerPrefs.GetInt(PLAYER_PREFS_RESOLUTION) == 1)
        {
            resolutionText1.color = normalColor;
            resolutionText2.color = selectedColor;
        }
    }
}
