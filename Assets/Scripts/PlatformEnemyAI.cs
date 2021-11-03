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

    private int direction = 1; // 1 - ������, -1 - �����
    private float radius = 0.01F; // ������ �������, ������������ ���������� �����

    private SpriteRenderer sprite;
    

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if ((direction > 0 && !Physics2D.OverlapCircle(rightObject.transform.position, radius, floor)) || // ����������� = ������ � ������ ��� �����
            (direction < 0 && !Physics2D.OverlapCircle(leftObject.transform.position, radius, floor)))    // ����������� = ����� � ����� ��� �����
            direction *= -1; // ������ �����������
        Run();
    }

    private void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(direction, 0, 0), speed * Time.deltaTime);

        sprite.flipX = direction < 0;
    }
}
