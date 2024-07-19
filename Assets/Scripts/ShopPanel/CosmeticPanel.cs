using UnityEngine;
using UnityEngine.UI;

public class CosmeticPanel : MonoBehaviour
{
    [SerializeField] 
    private Button newAbilitiesButton;
    [SerializeField] 
    private Button pigImprovementsButton;

    [Space(13)]
    
    [SerializeField] 
    private GameObject newAbilitiesPanel;
    [SerializeField] 
    private GameObject pigImprovementsPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] buyShieldButton;
    [SerializeField] 
    private GameObject[] costGameObject;

    [Space(13)]
    
    [SerializeField] 
    private ShopCoinManager coinManager;

    private int currentCoinAmount;
    private int[] costShield = {300, 400, 500};

    private void OnEnable()
    {
        currentCoinAmount = CoinData.Instance.GetCoinAmount();
        
        ButtonClickAction();
        SetActiveButton();
    }

    private void SetActiveButton()
    {
        for (int i = 0; i < buyShieldButton.Length; i++)
        {
            if (ShopData.Instance.IsBuyCosmetic(i))
            {
                buyShieldButton[i].gameObject.SetActive(false);
                costGameObject[i].SetActive(false);
            }
            else
            {
                buyShieldButton[i].gameObject.SetActive(true);
                costGameObject[i].SetActive(true);
            }
        }
    }

    private void BuyShield(int index)
    {
        if (currentCoinAmount >= costShield[index])
        {
            CoinData.Instance.SubtractCoin(costShield[index]);
            currentCoinAmount = CoinData.Instance.GetCoinAmount();
            coinManager.UpdateCoinText();
            
            ShopData.Instance.BuyCosmetic(index);
            SetActiveButton();
        }
    }

    private void ButtonClickAction()
    {
        if (newAbilitiesButton != null)
        {
            newAbilitiesButton.onClick.RemoveAllListeners();
            newAbilitiesButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                newAbilitiesPanel.SetActive(true);
            });
        }

        if (pigImprovementsButton != null)
        {
            pigImprovementsButton.onClick.RemoveAllListeners();
            pigImprovementsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                pigImprovementsPanel.SetActive(true);
            });
        }

        if (buyShieldButton[0] != null)
        {
            buyShieldButton[0].onClick.RemoveAllListeners();
            buyShieldButton[0].onClick.AddListener(() =>
            {
                BuyShield(0);
            });
        }

        if (buyShieldButton[1] != null)
        {
            buyShieldButton[1].onClick.RemoveAllListeners();
            buyShieldButton[1].onClick.AddListener(() =>
            {
                BuyShield(1);
            });
        }

        if (buyShieldButton[2] != null)
        {
            buyShieldButton[2].onClick.RemoveAllListeners();
            buyShieldButton[2].onClick.AddListener(() =>
            {
                BuyShield(2);
            });
        }
    }
}
