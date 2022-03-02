using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{


    public float StartTimeBtwHits;
    private float TimeBtwHits;
    bool isAttacking = false;
    private Animator anim;
    public GameObject AttackHitbox;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AttackHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        
        if (Input.GetMouseButton(0) && !isAttacking)
         {
             anim.Play("Player_Attack");
            AudioManager.instance.PlaySFX(3);
            StartCoroutine(DoAttack());
         }
        
    }

    IEnumerator DoAttack()
    {
        AttackHitbox.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        AttackHitbox.SetActive(false);

        isAttacking = false;
    }
}
