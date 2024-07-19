using TMPro;
using UnityEngine;

public class ShopCoinManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = CoinData.Instance.GetCoinAmount().ToString();
    }
}
