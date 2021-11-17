using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    public float flipTime = 0.1f;

    private bool playerIsNear = false; // игрок находится в триггере
    private Rigidbody2D rb;
    private GameObject player;
    private Stats stats;
    private bool flipping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        stats = GetComponent<Stats>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (playerIsNear)
        {
            if (!CheckFacingPlayer())
            {
                if (!flipping)
                {
                    StartCoroutine(FlipTimer());
                }
            }
            else
            {
                StopAllCoroutines();
                flipping = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerIsNear = true; // игрок подошёл
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerIsNear = false; // игрок отошёл
    }

    /// <summary>
    /// Проверяет, повернут ли персонаж в сторону игрока
    /// </summary>
    private bool CheckFacingPlayer()
    {
        bool playerFromLeft = player.transform.position.x < transform.position.x;
        bool playerFromRight = !playerFromLeft;
        return (playerFromLeft && transform.right.x < 0) || (playerFromRight && transform.right.x > 0);
    }

    /// <summary>
    /// Разворачивает персонажа
    /// </summary>
    private void Flip()
    {
        float y = transform.rotation.y;
        if (y == 0)
            y = 180;
        else
            y = 0;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }

    private IEnumerator FlipTimer()
    {
        flipping = true;
        yield return new WaitForSeconds(flipTime);
        Flip();
        flipping = false;
    }
}