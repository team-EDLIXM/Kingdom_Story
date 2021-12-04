using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotpos;
    public GameObject Bullet;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private bool FireballAbility;


    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && FireballAbility == true)
            {
                Instantiate(Bullet, shotpos.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
