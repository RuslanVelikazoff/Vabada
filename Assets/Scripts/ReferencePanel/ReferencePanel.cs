using UnityEngine;

public class ReferencePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] referencePanels;

    private void OnEnable()
    {
        for (int i = 0; i < referencePanels.Length; i++)
        {
            if (i == 0)
            {
                referencePanels[i].SetActive(true);
            }
            else
            {
                referencePanels[i].SetActive(false);
            }
        }
    }
}
