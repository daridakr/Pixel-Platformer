using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private Vector3 _position;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        _position = transform.position;

        if (_direction.magnitude > 0)
        {
            var delta = _direction * _speed * Time.deltaTime;
            transform.position = _position + new Vector3(delta.x, delta.y, _position.z);
        }
    }
}
