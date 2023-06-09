using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private UnityEvent _onComplete;

    private SpriteRenderer _renderer;
    private float _secondsPerFrame;
    private float _nextFrameTime;
    private int _currentSpriteIndex;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time + _secondsPerFrame;
        _currentSpriteIndex = 0;
    }

    private void Update()
    {
        if (_nextFrameTime > Time.time)
        {
            return;
        }
        else
        {
            TryAnimate();
        }
    }

    private void TryAnimate()
    {
        if (_currentSpriteIndex >= _sprites.Length)
        {
            if (_loop)
            {
                _currentSpriteIndex = 0;
            }
            else
            {
                enabled = false;
                _onComplete?.Invoke();
                return;
            }
        }

        Animate();
    }

    private void Animate()
    {
        _renderer.sprite = _sprites[_currentSpriteIndex];
        _nextFrameTime += _secondsPerFrame;
        _currentSpriteIndex++;
    }
}
