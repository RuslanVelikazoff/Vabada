using UnityEngine;
using UnityEngine.UI;

public class PauseButtonAction : MonoBehaviour
{
    [SerializeField] 
    private Button pauseButton;

    [SerializeField] 
    private GameObject pausePanel;

    private void Awake()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                pausePanel.SetActive(true);
            });
        }
    }
}
