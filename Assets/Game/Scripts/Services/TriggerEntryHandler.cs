using UnityEngine;
using UnityEngine.Events;

public class TriggerEntryHandler : MonoBehaviour
{
    [SerializeField] private TriggerTags _tag;
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_tag.ToString()))
        {
            _action?.Invoke();
        }
    }
}
