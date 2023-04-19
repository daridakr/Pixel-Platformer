using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerTouchChecker _groundCheck;

    private Vector2 _direction;
    private Rigidbody2D _body;
    private SpriteRenderer _sprite;

    public Vector2 Direction => _direction;
    public Vector2 Velocity => _body.velocity;
    public bool IsGrounded => _groundCheck.IsTouching;

    private void Awake()
    {
        _body= GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        Move();
        Jump(_direction.y > 0);

        UpdateSpriteDirection(_direction.x);
    }

    private void Move()
    {
        _body.velocity = new Vector2(_direction.x * _speed, _body.velocity.y);
    }

    private void UpdateSpriteDirection(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            _sprite.flipX = false;
        }
        else if (horizontalDirection < 0)
        {
            _sprite.flipX = true;
        }
    }

    private void Jump(bool isJumping)
    {
        if (isJumping)
        {
            if (IsGrounded)
            {
                _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
        else if (_body.velocity.y > 0)
        {
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * 0.5F);
        }
    }
}
