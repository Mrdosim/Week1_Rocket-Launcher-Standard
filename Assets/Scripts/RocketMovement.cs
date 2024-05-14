using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 5f;
    private readonly float ROTATIONSPEED = 0.01f;
    private float _currentSpeed;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _currentSpeed = SPEED;
    }
    
    public void ApplyMovement(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            Rotate(direction);
            Move();
        }
        else
        {
            _rb2d.velocity = Vector2.zero; // 방향 입력이 없으면 정지
        }
    }

    public void ApplyBoost(bool isPressed)
    {
        _currentSpeed = isPressed ? SPEED * 3 : SPEED;
    }

    private void Rotate(Vector2 direction)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, ROTATIONSPEED);
    }

    private void Move()
    {
        // TODO : 움직임 적용
        _rb2d.velocity = transform.up * _currentSpeed;
    }
}