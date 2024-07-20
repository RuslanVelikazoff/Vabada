using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdviceText : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI adviceText;

    [SerializeField] 
    private string[] advice;

    private void OnEnable()
    {
        SetAdviceText();
    }

    private void SetAdviceText()
    {
        int randomIndex = Random.Range(0, advice.Length);
        adviceText.text = advice[randomIndex];
    }
}
