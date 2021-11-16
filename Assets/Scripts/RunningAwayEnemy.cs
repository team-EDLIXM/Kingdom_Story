using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAwayEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0F;
    [SerializeField]
    private LayerMask floor;
    [SerializeField]
    private GameObject  wallCheck;
    [SerializeField]
    private GameObject floorCheck;
    //[SerializeField]
    //private GameObject player;

    private float radius = 0.01F; // радиус объекта, проверяющего отсутствие земли
    private bool isHurt = false; // ранен ли персонаж
    public bool nowhereToRun = false; // тупик
    private bool playerIsNear = false; // игрок находится в триггере
    private Rigidbody2D rb;
    private GameObject player;
    private EnemyFire EnemyFire; // скрипт стрельбы

    private void Start()
    {
        EnemyFire = GetComponent<EnemyFire>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // нанесение урона
        {
            isHurt = true;
        }
        if (nowhereToRun && playerIsNear && !EnemyFire.reloading)
        {
            EnemyFire.Fire();
        }
    }

    private void FixedUpdate()
    {
        if (isHurt && playerIsNear)
        {
            RunAway();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (!CheckFacingPlayer())
                Flip();
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
    /// Побег от игрока
    /// </summary>
    private void RunAway()
    {
        if (CheckFacingPlayer())
            Flip();

        CheckNowhereToRun();

        rb.velocity = new Vector2(transform.right.x * speed, rb.velocity.y);
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

    /// <summary>
    /// проверка на тупик
    /// </summary>
    private void CheckNowhereToRun()
    {
        bool isWall = Physics2D.OverlapCircle(wallCheck.transform.position, radius, floor);
        bool isFloor = Physics2D.OverlapCircle(floorCheck.transform.position, radius, floor);
        if (isWall || !isFloor)     // тупик слева
        {
            Flip();
            speed = 0; // останавливаемся
            nowhereToRun = true;
        }
    }
}
