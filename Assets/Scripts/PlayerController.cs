using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    private FireScript FireScript; // скрипт стрельбы
    private Stats stats;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        FireScript = GetComponent<FireScript>();
        stats = GetComponent<Stats>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();

        if (Input.GetMouseButton(0) && !FireScript.reloading)
        {
            FireScript.Fire();
        }

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
        if (Input.GetAxis("Horizontal") != 0)
        {
            Flip();
        }
        float moveVector = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveVector * stats.speed, rigidbody.velocity.y);
    }

    private void Jump()
    {
        rigidbody.AddForce(new Vector2(0F, jumpForce), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.3F, whatIsGround);
    }

}
