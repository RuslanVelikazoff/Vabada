using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb2D;

    [SerializeField] 
    private float defaultSpeed = 3.5f;
    [SerializeField] 
    private float leapForce = 6.5f;

    private float currentSpeed;

    private bool isRunning;
    private bool isLeaping;
    private bool onGround;

    private GameObject characterGameObject;
    private Animator characterAnimator;

    private void Start()
    {
        currentSpeed = 0f;
        defaultSpeed = 3.5f;
    }

    private void Update()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(rb2D.position, Vector2.down, 1f, 
            LayerMask.GetMask("Platform"));

        if (groundHit.collider != null)
        {
            onGround = true;
            isLeaping = false;
        }
        else
        {
            onGround = false;
            isLeaping = true;
        }

        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isJump", isLeaping);
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
    }

    public void MovePlayerRight()
    {
        characterGameObject.transform.rotation = new Quaternion(
            characterGameObject.transform.rotation.x,
            0,
            characterGameObject.transform.rotation.z,
            0);

        isRunning = true;
        
        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isWalk", isRunning);
        }

        if (currentSpeed <= 0f)
        {
            currentSpeed = defaultSpeed;
        }
    }

    public void MovePlayerLeft()
    {
        characterGameObject.transform.rotation = new Quaternion(
            characterGameObject.transform.rotation.x,
            180,
            characterGameObject.transform.rotation.z,
            0);

        isRunning = true;

        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isWalk", isRunning);
        }

        if (currentSpeed >= 0f)
        {
            currentSpeed = -defaultSpeed;
        }
    }

    public void ResetMove()
    {
        isRunning = false;

        if (characterAnimator != null)
        {
            characterAnimator.SetBool("isWalk", isRunning);
        }

        currentSpeed = 0f;
    }

    public void JumpPlayer()
    {
        if (onGround)
        {
            rb2D.velocity = Vector2.up * leapForce;
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        characterAnimator = animator;
    }

    public void SetPlayerSprite(GameObject player)
    {
        characterGameObject = player;
    }

    public void SetPlayerJumpForce(float jumpForce)
    {
        leapForce = jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlatform"))
        {
            GameManager.Instance.Lose();
        }
    }
}
