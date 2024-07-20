using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] startPanels;

    private void OnEnable()
    {
        for (int i = 0; i < startPanels.Length; i++)
        {
            if (i == 0)
            {
                startPanels[i].SetActive(true);
            }
            else
            {
                startPanels[i].SetActive(false);
            }
        }
    }
}
