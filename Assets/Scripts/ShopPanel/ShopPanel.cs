using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] shopPanels;

    private void OnEnable()
    {
        for (int i = 0; i < shopPanels.Length; i++)
        {
            if (i == 0)
            {
                shopPanels[i].SetActive(true);
            }
            else
            {
                shopPanels[i].SetActive(false);
            }
        }
    }
}
