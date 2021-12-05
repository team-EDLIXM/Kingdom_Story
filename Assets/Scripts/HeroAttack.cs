using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{


    public float StartTimeBtwHits;
    private float TimeBtwHits;
   
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBtwHits <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.Play("Player_Attack");
                TimeBtwHits = StartTimeBtwHits;
            }
        }
        else
        {
            TimeBtwHits -= Time.deltaTime;
        }
    }
}
