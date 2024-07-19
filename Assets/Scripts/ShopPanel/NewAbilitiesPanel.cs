using UnityEngine;
using UnityEngine.UI;

public class NewAbilitiesPanel : MonoBehaviour
{
    [SerializeField]
    private Button pigImprovementsButton;
    [SerializeField]
    private Button cosmeticButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject pigImprovementsPanel;
    [SerializeField]
    private GameObject cosmeticPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] buyAbilitiesButton;
    [SerializeField] 
    private GameObject[] costGameObject;

    [Space(13)]
    
    [SerializeField] 
    private ShopCoinManager coinManager;

    private int[] costAbilities = {200, 250, 300};
    private int currentCoinAmount;

    private void OnEnable()
    {
        currentCoinAmount = CoinData.Instance.GetCoinAmount();
        ButtonClickAction();
        SetActiveButtons();
    }

    private void ButtonClickAction()
    {
        if (pigImprovementsButton != null)
        {
            pigImprovementsButton.onClick.RemoveAllListeners();
            pigImprovementsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                pigImprovementsPanel.SetActive(true);
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

        if (buyAbilitiesButton[0] != null)
        {
            buyAbilitiesButton[0].onClick.RemoveAllListeners();
            buyAbilitiesButton[0].onClick.AddListener(() =>
            {
                BuyAbilities(0);
            });
        }

        if (buyAbilitiesButton[1] != null)
        {
            buyAbilitiesButton[1].onClick.RemoveAllListeners();
            buyAbilitiesButton[1].onClick.AddListener(() =>
            {
                BuyAbilities(1);
            });
        }

        if (buyAbilitiesButton[2] != null)
        {
            buyAbilitiesButton[2].onClick.RemoveAllListeners();
            buyAbilitiesButton[2].onClick.AddListener(() =>
            {
                BuyAbilities(2);
            });
        }
    }

    private void SetActiveButtons()
    {
        for (int i = 0; i < buyAbilitiesButton.Length; i++)
        {
            if (ShopData.Instance.IsBuyAbilities(i))
            {
                buyAbilitiesButton[i].gameObject.SetActive(false);
                costGameObject[i].SetActive(false);
            }
            else
            {
                buyAbilitiesButton[i].gameObject.SetActive(true);
                costGameObject[i].SetActive(true);
            }
        }
    }

    private void BuyAbilities(int index)
    {
        if (currentCoinAmount >= costAbilities[index])
        {
            CoinData.Instance.SubtractCoin(costAbilities[index]);
            currentCoinAmount = CoinData.Instance.GetCoinAmount();
            coinManager.UpdateCoinText();
            
            ShopData.Instance.BuyAbilities(index);
            SetActiveButtons();
        }
    }
}
