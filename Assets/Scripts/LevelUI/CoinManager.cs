using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI coinText;

    private int coinAmount;
    
    private void Awake()
    {
        Instance = this;
        SetCoinText();
    }

    private void SetCoinText()
    {
        coinText.text = coinAmount.ToString();
    }

    public void AddCoin(int amount)
    {
        coinAmount += amount;
        SetCoinText();
    }

    public int GetCoinAmount()
    {
        return coinAmount;
    }
}
