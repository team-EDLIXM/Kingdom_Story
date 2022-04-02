using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPlant : MonoBehaviour
{
    private Animator anim;
    private bool playerIsNear = false; // игрок находится в триггере
    private Rigidbody2D rb;
    private GameObject player;
    private SnapPlantShot fireScript; // скрипт стрельбы
    private Stats stats;

    private bool reloadingAttack = false;
    public float reloadAttackTime = 2;
    public int attacksInRow = 3;

    public int currentAttack = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        fireScript = GetComponent<SnapPlantShot>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (playerIsNear && !reloadingAttack && !fireScript.reloading)
        {
            //fireScript.Fire();
            anim.SetBool("IsAttacking", true);
            //currentAttack++;
            if (currentAttack >= attacksInRow)
            {
                anim.SetBool("IsAttacking", false);
                StartCoroutine(RealoadAttackTimer());
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerIsNear && !CheckFacingPlayer())
            Flip();
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

    private IEnumerator RealoadAttackTimer()
    {
        reloadingAttack = true;
        stats.isInvulnerable = true;
        yield return new WaitForSeconds(reloadAttackTime);
        reloadingAttack = false;
        stats.isInvulnerable = false;
        currentAttack = 0;
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
}