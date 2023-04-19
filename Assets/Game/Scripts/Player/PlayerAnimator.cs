using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool(IsGrounded, _movement.IsGrounded);
        _animator.SetFloat(VerticalVelocity, _movement.Velocity.y);
        _animator.SetBool(IsRunning, _movement.Direction.x != 0);
    }
}
