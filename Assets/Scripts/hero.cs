using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hero : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private float mInput;
    private Rigidbody2D rb;
    private bool fRigth = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    private int extraJump;
    public int extraJumpValue;

    public int maxhealth = 5;
    public int health;

    public AudioManager AudioManager;

    public void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        health = maxhealth;
        AudioManager = GameObject.Find("AudioManager script").GetComponent<AudioManager>();
    }

    public void Update()
    {
        if (isGrounded)
        {
            extraJump = extraJumpValue;
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJump--;
            AudioManager.instance.PlaySFX(1);
        }

        else if (Input.GetKeyDown(KeyCode.Space)  && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            AudioManager.instance.PlaySFX(1);
        }

        ;
        
        
    }


    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        mInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mInput * speed, rb.velocity.y);

        if (fRigth == false && mInput > 0 )
        {
            Flip();
        }
        else if (fRigth == true && mInput < 0)
        {
            Flip();
        }
        if (rb.velocity.x != 0 && isGrounded && !AudioManager.sounds[0].isPlaying)
        {
            AudioManager.instance.PlaySFX(0);
        }
    }

    void Flip() 
    {
        fRigth = !fRigth;
        transform.Rotate(0f, 180f, 0f);

    }


   /* public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        extraJumpValue += 1;
    }*/




}
