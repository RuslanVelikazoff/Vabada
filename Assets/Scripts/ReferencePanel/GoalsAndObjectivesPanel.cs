using UnityEngine;
using UnityEngine.UI;

public class GoalsAndObjectivesPanel : MonoBehaviour
{
    [SerializeField]
    private Button howToPlayButton;
    [SerializeField] 
    private Button FAQButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject howToPlayPanel;
    [SerializeField] 
    private GameObject FAQPanel;

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

        if (FAQButton != null)
        {
            FAQButton.onClick.RemoveAllListeners();
            FAQButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                FAQPanel.SetActive(true);
            });
        }
    }
}
