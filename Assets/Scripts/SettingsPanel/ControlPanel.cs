using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] 
    private Button soundButton;
    [SerializeField] 
    private Button graphicButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject soundPanel;
    [SerializeField] 
    private GameObject graphicPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button beginnerButton;
    [SerializeField] 
    private TextMeshProUGUI beginnerText;
    [SerializeField] 
    private Button proButton;
    [SerializeField]
    private TextMeshProUGUI proText;

    [Space(13)]
    
    [SerializeField] 
    private Slider sensitivitySlider;
    private float sensitivity = .5f;

    [Space(13)]
    
    [SerializeField]
    private Button resetButton;

    [Space(13)]
    
    [SerializeField] 
    private Color selectedColor;
    [SerializeField] 
    private Color normalColor;

    private const string PLAYER_PREFS_CONTROL = "Control";
    private const string PLAYER_PREFS_SENSITIVITY = "Sensitivity";
    private const string BEGINNER = "Beginner";
    private const string PRO = "Pro";

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey(PLAYER_PREFS_CONTROL))
        {
            PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, BEGINNER);
        }
        if (!PlayerPrefs.HasKey(PLAYER_PREFS_SENSITIVITY))
        {
            PlayerPrefs.SetFloat(PLAYER_PREFS_SENSITIVITY, sensitivity);
        }

        sensitivitySlider.value = PlayerPrefs.GetFloat(PLAYER_PREFS_SENSITIVITY);
        SetControlButton();
        ButtonFunctions();
    }

    private void OnDisable()
    {
        sensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat(PLAYER_PREFS_SENSITIVITY, sensitivity);
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

        if (graphicButton != null)
        {
            graphicButton.onClick.RemoveAllListeners();
            graphicButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                graphicPanel.SetActive(true);
            });
        }

        if (beginnerButton != null)
        {
            beginnerButton.onClick.RemoveAllListeners();
            beginnerButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, BEGINNER);
                SetControlButton();
            });
        }

        if (proButton != null)
        {
            proButton.onClick.RemoveAllListeners();
            proButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, PRO);
                SetControlButton();
            });
        }

        if (resetButton != null)
        {
            resetButton.onClick.RemoveAllListeners();
            resetButton.onClick.AddListener(() =>
            {
                ResetControlSettings();
            });
        }
    }

    private void SetControlButton()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_CONTROL) == BEGINNER)
        {
            beginnerText.color = selectedColor;
            proText.color = normalColor;
        }
        if (PlayerPrefs.GetString(PLAYER_PREFS_CONTROL) == PRO)
        {
            beginnerText.color = normalColor;
            proText.color = selectedColor;
        }
    }

    private void ResetControlSettings()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_CONTROL, BEGINNER);
        sensitivity = .5f;
        PlayerPrefs.SetFloat(PLAYER_PREFS_SENSITIVITY, sensitivity);
        sensitivitySlider.value = sensitivity;
        SetControlButton();
    }
}
