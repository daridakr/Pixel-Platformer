using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _direction;

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction != 0)
        {
            float delta = _direction * _speed * Time.deltaTime;
            float newXPosition = transform.position.x + delta;
            transform.position = new Vector2(newXPosition, transform.position.y);
        }
    }
}
