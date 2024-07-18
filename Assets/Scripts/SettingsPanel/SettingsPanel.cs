using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] settingPanels;

    private void OnEnable()
    {
        for (int i = 0; i < settingPanels.Length; i++)
        {
            if (i == 0)
            {
                settingPanels[i].SetActive(true);
            }
            else
            {
                settingPanels[i].SetActive(false);
            }
        }
    }
}
