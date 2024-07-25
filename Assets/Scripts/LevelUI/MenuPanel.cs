using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button menuButton;

    private void OnEnable()
    {
        ButtonFunctions();
        Time.timeScale = 0f;
    }

    private void ButtonFunctions()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            });
        }

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
