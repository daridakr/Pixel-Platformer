using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _groundCheckFilter;
    [SerializeField] private float _groundChekDistance = 0.1F;

    private Vector2 _direction;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body= GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        Move();

        bool isJumping = _direction.y > 0;
        if (isJumping && IsGrounded())
        {
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        _body.velocity = new Vector2(_direction.x * _speed, _body.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] results = new RaycastHit2D[1];
        int collisionCount = _body.Cast(Vector2.down, _groundCheckFilter, results, _groundChekDistance);
        return collisionCount != 0;
    }
}
