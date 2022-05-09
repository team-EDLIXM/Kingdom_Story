using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
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

    private Animator anim;
    private Stats stats;
    private HeroAttack heroAttack;

    public AudioManager AudioManager;

    private float normalGravity; 
    
    //cheats
    private HolderScript holder;
    public void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        anim = GetComponent<Animator>();
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        stats = GetComponent<Stats>();
        heroAttack = GetComponent<HeroAttack>();
        
        holder = FindObjectOfType<HolderScript>();
        stats.dmg = holder.Damage;
        stats.freezeHP = holder.areFreeze;
    }

    public void Update()
    {
        if (Time.timeScale == 0) return;

        if (stats.health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (isGrounded)
        {
            extraJump = extraJumpValue;
        }

        if (!stats.isPushed)
        {
            if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
            {
                rb.velocity = Vector2.up * jumpHeight;
                extraJump--;
                AudioManager.instance.PlaySFX(1);
                anim.SetTrigger("Jump");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded)
            {
                rb.velocity = Vector2.up * jumpHeight;
                AudioManager.instance.PlaySFX(1);
                anim.SetTrigger("Jump");
            }
        }
    }


    public Vector2 otherVelocity = Vector2.zero;

    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        mInput = Input.GetAxis("Horizontal");
        if (stats.isPushed) mInput = 0;
        var v = new Vector2(mInput * stats.speed, rb.velocity.y);
        if (stats.isPushed)
        {
            v.x += otherVelocity.x;
            v.y += otherVelocity.y;
        }

        rb.velocity = v;
        if (!heroAttack.isAttacking)
        {
            if (!fRigth && mInput > 0)
            {
                Flip();
            }
            else if (fRigth && mInput < 0)
            {
                Flip();
            }
        }

        if (rb.velocity.x != 0 && isGrounded && !AudioManager.sounds[0].isPlaying)
        {
            AudioManager.instance.PlaySFX(0);
        }

        float fallAxis = Input.GetAxisRaw("Vertical");
        if (fallAxis < 0)
            rb.gravityScale = normalGravity * 1.8f;
        else
            rb.gravityScale = normalGravity;
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
