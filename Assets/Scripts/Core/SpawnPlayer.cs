using System.Collections;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] player;
    [SerializeField] 
    private Animator[] playerAnimator;

    [SerializeField] 
    private PlayerMovement playerMovement;
    [SerializeField] 
    private PlayerHealth playerHealth;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        SetPlayer();
        SetPlayerHealth();
    }

    private void SetPlayer()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (ShopData.Instance.IsBuyCosmetic(i))
            {
                player[i].SetActive(true);
                playerMovement.SetPlayerSprite(player[i]);
                //playerMovement.SetPlayerAnimator(playerAnimator[i]);
            }
            else
            {
                player[i].SetActive(false);
            }
        }
    }

    private void SetPlayerHealth()
    {
        int health = 40 + ShopData.Instance.GetImproveLevel(0) * 10;
        playerHealth.SetHealthBar(health);
    }
}
