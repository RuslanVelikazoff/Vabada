using UnityEngine;
using UnityEngine.UI;

public class ReferenceBackButtonAction : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    
    [Space(13)]
    
    [SerializeField] 
    private GameObject referencePanel;
    [SerializeField] 
    private GameObject mainMenuPanel;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                referencePanel.SetActive(false);
                mainMenuPanel.SetActive(true);
            });
        }
    }
}
