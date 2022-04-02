using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private bool playerIsNear = false; // èãðîê íàõîäèòñÿ â òðèããåðå
    private GameObject player;
    //private FireScript fireScript; // ñêðèïò ñòðåëüáû
    private Stats stats;
    private SpriteRenderer _sr;
    public Animator anim;

    public float shotDelay = 0.1f;
    private bool isDelay = false;
    private bool reloadingAttack = false;
    public float reloadAttackTime = 2;
    public int attacksInRow = 3;
    public float responseRadius = 5f;
    public Transform seedFirePoint;
    public GameObject seed;

    private int currentAttack = 0;

    private void Awake()
    {
        //fireScript = GetComponent<FireScript>();
        player = GameObject.FindWithTag("Player");
        stats = GetComponent<Stats>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        playerIsNear = Vector3.Distance(gameObject.transform.position, player.transform.position) < responseRadius ? true : false;
        if (playerIsNear && !reloadingAttack && !isDelay)
        {
            anim.SetBool("isAttacking", true);  
        }
    }

    private void FixedUpdate()
    {
        if (playerIsNear && !CheckFacingPlayer())
            Flip();
    }

    private IEnumerator RealoadAttackTimer()
    {
        reloadingAttack = true;
        stats.isInvulnerable = true;
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0.5f);
        yield return new WaitForSeconds(reloadAttackTime);
        reloadingAttack = false;
        stats.isInvulnerable = false;
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1f);
        currentAttack = 0;
    }

    /// <summary>
    /// Ïðîâåðÿåò, ïîâåðíóò ëè ïåðñîíàæ â ñòîðîíó èãðîêà
    /// </summary>
    private bool CheckFacingPlayer()
    {
        bool playerFromLeft = player.transform.position.x < transform.position.x;
        bool playerFromRight = !playerFromLeft;
        return !((playerFromLeft && transform.right.x < 0) || (playerFromRight && transform.right.x > 0));
    }

    /// <summary>
    /// Ðàçâîðà÷èâàåò ïåðñîíàæà
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

    // Столкновение с игроком
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().TakeDamage(stats.dmg);
        }
    }

    // Задержка между выстрелами
    private IEnumerator ShotDelay()
    {
        isDelay = true;
        yield return new WaitForSeconds(shotDelay);
        isDelay = false;
    }

    // Сам выстрел
    void shot()
    {
        anim.SetBool("isAttacking", false);
        if (currentAttack++ < attacksInRow)
        {
            var newSeed = Instantiate(seed, seedFirePoint.position, seedFirePoint.rotation);
            StartCoroutine(ShotDelay());
        }
        else
        {
            currentAttack = 0;
            StartCoroutine(RealoadAttackTimer());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, responseRadius);
    }
}