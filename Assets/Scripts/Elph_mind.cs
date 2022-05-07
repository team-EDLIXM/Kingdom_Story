using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elph_mind : MonoBehaviour
{
    public Transform theElph;
    public GameObject thePlayer;

    private bool shotReload = false;
    private bool isDelay = false;
    public int maxShotsCount = 5;
    private int shotsCount = 0;
    public float shotDelay = 0.1f;
    public float shotReloadTime = 3f;
    public GameObject fireball;
    public Transform fireballPoint;

    private bool swapReload = false;
    public float swapReloadTime = 5f;

    private void Awake()
    {
        thePlayer = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(theElph.position, thePlayer.transform.position);
        if (distance < 30 && !shotReload && !isDelay)
        {
            if (distance < 15 && !swapReload)
            {
                swap();
            }
            shot();
        }
    }

    void shot()
    {
        if (shotsCount++ < maxShotsCount)
        {
            Vector3 difference = fireballPoint.position - thePlayer.transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            fireballPoint.rotation = Quaternion.Euler(0f, 0f, rotateZ);
            var newFireBall = Instantiate(fireball, fireballPoint.position, fireballPoint.rotation);
            StartCoroutine(ShotDelay());
        }
        else
        {
            shotsCount = 0;
            StartCoroutine(ReloadShot());
        }
    }

    void swap()
    {
        Vector3 temp = theElph.position;
        theElph.position = thePlayer.transform.position;
        thePlayer.transform.position = temp;
        StartCoroutine(ReloadSwap());
    }

    private IEnumerator ReloadSwap()
    {
        swapReload = true;
        yield return new WaitForSeconds(swapReloadTime);
        swapReload = false;
    }

    private IEnumerator ReloadShot()
    {
        shotReload = true;
        yield return new WaitForSeconds(shotReloadTime);
        shotReload = false;
    }

    private IEnumerator ShotDelay()
    {
        isDelay = true;
        yield return new WaitForSeconds(shotDelay);
        isDelay = false;
    }
}
