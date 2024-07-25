using UnityEngine;
using UnityEngine.UI;

public class HowToPlayPanel : MonoBehaviour
{
    [SerializeField] 
    private Button goalsAndObjectivesButton;
    [SerializeField] 
    private Button FAQButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject goalsAndObjectivesPanel;
    [SerializeField] 
    private GameObject FAQPanel;

    private void OnEnable()
    {
        ButtonFunctions();
    }

    private void ButtonFunctions()
    {
        if (goalsAndObjectivesButton != null)
        {
            goalsAndObjectivesButton.onClick.RemoveAllListeners();
            goalsAndObjectivesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                goalsAndObjectivesPanel.SetActive(true);
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
