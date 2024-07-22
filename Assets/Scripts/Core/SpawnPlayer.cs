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
    [SerializeField] 
    private PlayerAttack playerAttack;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);

        SetPlayer();
        SetPlayerHealth();
        SetPlayerAttack();
    }

    private void SetPlayer()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (ShopData.Instance.IsBuyCosmetic(i))
            {
                player[i].SetActive(true);
                playerMovement.SetPlayerSprite(player[i]);
                playerAttack.SetPlayerGameObject(player[i]);
                //playerAttack.SetPlayerAnimator(playerAnimator[i]);
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
        playerHealth.SetMiss(ShopData.Instance.IsBuyAbilities(0));
    }

    private void SetPlayerAttack()
    {
        float attackDelay = 0;

        if (ShopData.Instance.IsBuyAbilities(1))
        {
            attackDelay = .7f;
        }
        else
        {
            attackDelay = 1.5f;
        }

        attackDelay -= (float)ShopData.Instance.GetImproveLevel(1) / 10;
        
        Debug.Log(attackDelay);
        
        playerAttack.SetPlayerAttackDelay(attackDelay);
    }
}
