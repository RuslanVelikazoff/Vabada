using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button shopButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField] 
    private Button referenceButton;
    [SerializeField]
    private Button exitButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject selectLocationPanel;
    [SerializeField] 
    private GameObject shopPanel;
    [SerializeField] 
    private GameObject settingsPanel;
    [SerializeField] 
    private GameObject referencePanel;

    private void Awake()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                selectLocationPanel.SetActive(true);
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (referenceButton != null)
        {
            referenceButton.onClick.RemoveAllListeners();
            referenceButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                referencePanel.SetActive(true);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
