using UnityEngine;
using UnityEngine.UI;

public class ImprovementsPanel : MonoBehaviour
{
    [SerializeField]
    private Button abilitiesButton;
    [SerializeField] 
    private Button cosmeticButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject abilitiesPanel;
    [SerializeField]
    private GameObject cosmeticPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] improveButton;
    [SerializeField] 
    private Improvement[] improvements;

    [Space(13)]
    
    [SerializeField] 
    private ShopCoinManager coinManager;

    private void OnEnable()
    {
        ButtonFunctions();
    }

    private void ButtonFunctions()
    {
        if (abilitiesButton != null)
        {
            abilitiesButton.onClick.RemoveAllListeners();
            abilitiesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                abilitiesPanel.SetActive(true);
            });
        }

        if (cosmeticButton != null)
        {
            cosmeticButton.onClick.RemoveAllListeners();
            cosmeticButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                cosmeticPanel.SetActive(true);
            });
        }

        if (improveButton[0] != null)
        {
            improveButton[0].onClick.RemoveAllListeners();
            improveButton[0].onClick.AddListener(() =>
            {
                if (improvements[0].BuyImprove())
                {
                    coinManager.UpdateCoinText();
                }
            });
        }

        if (improveButton[1] != null)
        {
            improveButton[1].onClick.RemoveAllListeners();
            improveButton[1].onClick.AddListener(() =>
            {
                if (improvements[1].BuyImprove())
                {
                    coinManager.UpdateCoinText();
                }
            });
        }
        
        if (improveButton[2] != null)
        {
            improveButton[2].onClick.RemoveAllListeners();
            improveButton[2].onClick.AddListener(() =>
            {
                if (improvements[2].BuyImprove())
                {
                    coinManager.UpdateCoinText();
                }
            });
        }
    }
}
