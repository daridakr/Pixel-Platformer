using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Vector3 _groundCheckPositionDelta;
    [SerializeField] private float _groundCheckRadius;

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
        var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
        return hit.collider != null;
    }
}
