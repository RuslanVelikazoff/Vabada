using UnityEngine;
using UnityEngine.UI;

public class FAQPanel : MonoBehaviour
{
    [SerializeField]
    private Button howToPlayButton;
    [SerializeField]
    private Button goalsAndObjectivesButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject howToPlayPanel;
    [SerializeField] 
    private GameObject goalsAndObjectivesPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (howToPlayButton != null)
        {
            howToPlayButton.onClick.RemoveAllListeners();
            howToPlayButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                howToPlayPanel.SetActive(true);
            });
        }

        if (goalsAndObjectivesButton != null)
        {
            goalsAndObjectivesButton.onClick.RemoveAllListeners();
            goalsAndObjectivesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                goalsAndObjectivesPanel.SetActive(true);
            });
        }
    }
}
