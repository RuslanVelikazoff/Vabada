using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Improvement : MonoBehaviour
{
    [SerializeField] 
    private int improveIndex;

    [SerializeField] 
    private TextMeshProUGUI improveCostText;

    [SerializeField]
    private GameObject improveCostGameObject;

    [SerializeField] 
    private Slider progressSlider;

    [SerializeField] 
    private Button improveButton;

    private int[] costImprove = {100, 200, 300, 400, 500};
    private int currentImproveLevel;
    private int maxImproveLevel = 5;

    private void OnEnable()
    {
        currentImproveLevel = ShopData.Instance.GetImproveLevel(improveIndex);
        
        SetProgressSliderValue();
        SetCostText();
        SetActiveGameObjects();
    }

    public bool BuyImprove()
    {
        if (currentImproveLevel < maxImproveLevel)
        {
            if (CoinData.Instance.GetCoinAmount() >= costImprove[currentImproveLevel - 1])
            {
                CoinData.Instance.SubtractCoin(costImprove[currentImproveLevel - 1]);
                ShopData.Instance.BuyImprove(improveIndex);
                
                currentImproveLevel = ShopData.Instance.GetImproveLevel(improveIndex);
                SetProgressSliderValue();
                SetCostText();
                SetActiveGameObjects();
                
                return true;
            }
        }

        return false;
    }

    private void SetActiveGameObjects()
    {
        if (currentImproveLevel >= maxImproveLevel)
        {
            improveCostGameObject.SetActive(false);
            improveButton.gameObject.SetActive(false);
        }
    }

    private void SetCostText()
    {
        improveCostText.text = costImprove[currentImproveLevel - 1].ToString();
    }

    private void SetProgressSliderValue()
    {
        progressSlider.value = currentImproveLevel;
    }
}
