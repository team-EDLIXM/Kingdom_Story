using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnim : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Space) )
        {
            anim.SetTrigger("Jump");
        }*/
        if (Time.timeScale == 0) return;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        
    }

    

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Spikes")
        {

            anim.SetBool("IsHurt", true);
        }
        else
        {
            anim.SetBool("IsHurt", false);
        }
    }*/



}
