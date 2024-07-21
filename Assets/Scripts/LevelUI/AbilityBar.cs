using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] 
    private Image[] abilityImage;

    [SerializeField] 
    private Sprite[] abilityActiveSprite;
    [SerializeField] 
    private Sprite[] abilityInactiveSprite;
    
    public void SetAbilityBar()
    {
        for (int i = 0; i < abilityImage.Length; i++)
        {
            if (ShopData.Instance.IsBuyAbilities(i))
            {
                abilityImage[i].sprite = abilityActiveSprite[i];
            }
            else
            {
                abilityImage[i].sprite = abilityInactiveSprite[i];
            }
        }
    }
}
