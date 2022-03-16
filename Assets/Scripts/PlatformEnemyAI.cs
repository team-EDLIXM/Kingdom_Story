using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyAI : MonoBehaviour
{
    [SerializeField] 
    private LayerMask floor;
    [SerializeField]
    private GameObject floorCheck;

    private Stats stats;
    private float radius = 0.01F; // радиус объекта, проверяющего отсутствие земли

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (!Physics2D.OverlapCircle(floorCheck.transform.position, radius, floor))  // направление = влево и слева нет земли
            Flip(); // меняем направление
        Run();
    }

    /// <summary>
    /// Разворачивает персонажа
    /// </summary>
    private void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(transform.right.x, 0, 0), stats.speed * Time.deltaTime);
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
