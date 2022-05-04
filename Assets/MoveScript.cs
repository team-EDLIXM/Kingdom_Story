using UnityEngine;

/// <summary>
/// Просто перемещает текущий объект игры
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - переменные

    /// <summary>
    /// Скорость объекта
    /// </summary>
    public Vector2 speed = new Vector2(5, 0);

    /// <summary>
    /// Направление движения
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        // 2 - Перемещение
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Применить движение к Rigidbody
        rb.velocity = movement;
    }
}