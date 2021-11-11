using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField]
    private GameObject groundCheck;
    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded = false;
    private bool doubleJumpAvailable = false;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            doubleJumpAvailable = true;
        }
        else if (doubleJumpAvailable && Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.velocity = new Vector2(0f, 0f);
            Jump();
            doubleJumpAvailable = false;
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
    }

    private void Jump()
    {
        rigidbody.AddForce(new Vector2(0F, jumpForce), ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.3F, whatIsGround);
    }

}
