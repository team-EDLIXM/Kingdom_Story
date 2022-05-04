using UnityEngine;

/// <summary>
/// ������ ���������� ������� ������ ����
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - ����������

    /// <summary>
    /// �������� �������
    /// </summary>
    public Vector2 speed = new Vector2(5, 0);

    /// <summary>
    /// ����������� ��������
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        // 2 - �����������
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // ��������� �������� � Rigidbody
        rb.velocity = movement;
    }
}