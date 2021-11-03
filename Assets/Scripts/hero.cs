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

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    private int extraJump;
    public int extraJumpValue;

    public void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
       
    }

    public void Update()
    {
        if (isGrounded)
        {
            extraJump = extraJumpValue;
            
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJump--;
            
        }

        else if (Input.GetKeyDown(KeyCode.W)  && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            
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
    }

    void Flip() 
    {
        fRigth = !fRigth;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }


   /* public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        extraJumpValue += 1;
    }*/




}
