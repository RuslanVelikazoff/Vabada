using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] 
    private float attackCooldown;

    private bool attacking = false;

    private GameObject character;
    private Animator characterAnimator;

    private void Update()
    {
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isAttack", attacking);
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        characterAnimator = animator;
    }

    public void SetPlayerGameObject(GameObject player)
    {
        this.character = player;
    }

    public void SetPlayerAttackDelay(float delay)
    {
        attackCooldown = delay;
    }

    public void Attack()
    {
        if (!attacking)
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
        attacking = true;

        yield return new WaitForSeconds(attackCooldown);

        attacking = false;
    }
}
