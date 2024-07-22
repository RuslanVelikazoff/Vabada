using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;

    [SerializeField]
    private int damage;

    private bool isAttack;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position,
            Vector2.left, 1f, 
            LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
        
        Debug.Log(isAttack);
        
        animator.SetBool("isAttack", isAttack);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.DamagePlayer(damage);
        }
    }
}
