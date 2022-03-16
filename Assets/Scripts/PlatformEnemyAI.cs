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
    private float radius = 0.01F; // ������ �������, ������������ ���������� �����

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (!Physics2D.OverlapCircle(floorCheck.transform.position, radius, floor))  // ����������� = ����� � ����� ��� �����
            Flip(); // ������ �����������
        Run();
    }

    /// <summary>
    /// ������������� ���������
    /// </summary>
    private void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(transform.right.x, 0, 0), stats.speed * Time.deltaTime);
    }

    /// <summary>
    /// ������������� ���������
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
