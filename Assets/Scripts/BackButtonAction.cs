using UnityEngine;
using UnityEngine.UI;

public class BackButtonAction : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    
    [Space(13)]
    
    [SerializeField] 
    private GameObject closePanel;
    [SerializeField] 
    private GameObject openPanel;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                closePanel.SetActive(false);
                openPanel.SetActive(true);
            });
        }
    }
}
