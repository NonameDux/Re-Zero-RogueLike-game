using UnityEngine;
using System.Collections;
using System;
public class PlayerManager : MonoBehaviour
{
    private bool isMoving,isAtacking,isStaying,inJump;
    public bool isLeft = false;
    private bool isJumpPressed,isLeftPressed,isRightPressed,isLMBPressed;
    private IEnumerator coroutine;
    //Player HitBox
    private Rigidbody2D rb;
    private CapsuleCollider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    //Ground hitbox
    private Vector2 boxSize;
    private float rayCastDistance;

    //Public references
    public LayerMask groundMask;
    public bool isOnGround;
    public Animator animator;
    [SerializeField] private GameObject AttackZone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Attack()
    {
        isAtacking = true;
        AttackZone.SetActive(true);
        animator.SetBool("isAtacking",true);
        yield return new WaitForSeconds(0.2f);
        AttackZone.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAtacking",false);
        isAtacking = false;
    }
    
    void Start()
    {
        //Getting player components
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<CapsuleCollider2D>();

        boxSize = new Vector2(playerCollider.bounds.size.x * 0.9f, 0.05f);
        rayCastDistance = playerCollider.bounds.extents.y + 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        isJumpPressed = UnityEngine.InputSystem.Keyboard.current.spaceKey.isPressed;

        isLeftPressed = UnityEngine.InputSystem.Keyboard.current.aKey.isPressed;
        isRightPressed = UnityEngine.InputSystem.Keyboard.current.dKey.isPressed;

        isLMBPressed = UnityEngine.InputSystem.Mouse.current.leftButton.isPressed;
    }
    void FixedUpdate()
    {
        Vector2 PlayerCenter = playerCollider.bounds.center;
        RaycastHit2D hit = Physics2D.BoxCast(PlayerCenter,boxSize,0f,Vector2.down,rayCastDistance,groundMask);

        isOnGround = (hit.collider != null);



        if(!isRightPressed && !isLeftPressed)
        { 
            rb.linearVelocity = new Vector2(0f,rb.linearVelocityY);
            
            isMoving = false;
        }
        if (isRightPressed)
            {
                rb.linearVelocity = new Vector2(5f, rb.linearVelocityY);
                isMoving = true;
                if(isLeft == true){isLeft = false; spriteRenderer.flipX = false;}
            }
        if (isLeftPressed)
            {
                rb.linearVelocity = new Vector2(-5f, rb.linearVelocityY);
                isMoving = true;
                if(isLeft == false){isLeft = true; spriteRenderer.flipX = true;}
            }
        if (isJumpPressed && isOnGround)
            {
                rb.AddForceY(100f);
            }
        if(isLMBPressed && !isAtacking)
        {
            coroutine = Attack();
            StartCoroutine(coroutine);
        }

        //Animations
        animator.SetFloat("Speed",Math.Abs(rb.linearVelocityX));
        animator.SetBool("isOnGround",isOnGround);
        
    }
}
