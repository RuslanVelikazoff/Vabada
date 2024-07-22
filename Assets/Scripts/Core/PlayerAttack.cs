using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] 
    private float attackDelay;

    private bool isAttack = false;

    private GameObject player;
    private Animator playerAnimator;

    private void Update()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isAttack", isAttack);
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        playerAnimator = animator;
    }

    public void SetPlayerGameObject(GameObject player)
    {
        this.player = player;
    }

    public void SetPlayerAttackDelay(float delay)
    {
        attackDelay = delay;
    }

    public void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackCO());
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position,
                1f, LayerMask.GetMask("Enemy"));
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }

    private IEnumerator AttackCO()
    {
        isAttack = true;

        yield return new WaitForSeconds(attackDelay);

        isAttack = false;
    }
}
