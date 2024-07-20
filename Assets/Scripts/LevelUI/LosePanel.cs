using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] 
    private Button restartButton;
    [SerializeField]
    private Button menuButton;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField] 
    private TextMeshProUGUI timeText;
    
    public void OpenPanel()
    {
        Time.timeScale = 0f;
        this.gameObject.SetActive(true);
        coinText.text = CoinManager.Instance.GetCoinAmount().ToString();
        timeText.text = TimerManager.Instance.GetTimerText();
        
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                Loader.Load("MainMenu");
            });
        }
    }
}
