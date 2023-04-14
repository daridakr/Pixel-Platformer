using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _body;
    private Vector2 _direction;

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
        _body.velocity = new Vector2(_direction.x * _speed, _body.velocity.y);
    }
}
