using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed = 1;

    private Vector2 TargetPosition => _target.position;

    private void LateUpdate()
    {
        Vector3 newTargetPosition = new Vector3(TargetPosition.x, TargetPosition.y, transform.position.z);
        Follow(newTargetPosition);
    }

    private void Follow(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _followSpeed);
    }
}
