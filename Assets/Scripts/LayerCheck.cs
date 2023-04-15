using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] LayerMask _layer;

    private Collider2D _collider;
    private bool _isTouching;

    public bool IsTouching => _isTouching;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isTouching = _collider.IsTouchingLayers(_layer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouching = _collider.IsTouchingLayers(_layer);
    }
}
