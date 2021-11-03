using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0F;
    [SerializeField] 
    private LayerMask floor;
    [SerializeField]
    private GameObject rightObject;
    [SerializeField]
    private GameObject leftObject;

    private int direction = 1; // 1 - вправо, -1 - влево
    private float radius = 0.01F; // радиус объекта, проверяющего отсутствие земли

    private SpriteRenderer sprite;
    

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if ((direction > 0 && !Physics2D.OverlapCircle(rightObject.transform.position, radius, floor)) || // направление = вправо и справа нет земли
            (direction < 0 && !Physics2D.OverlapCircle(leftObject.transform.position, radius, floor)))    // направление = влево и слева нет земли
            direction *= -1; // меняем направление
        Run();
    }

    private void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(direction, 0, 0), speed * Time.deltaTime);

        sprite.flipX = direction < 0;
    }
}
