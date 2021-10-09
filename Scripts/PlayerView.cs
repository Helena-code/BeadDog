using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PlayerInteract _playerController;
    private PlayerMove _playerMove;
    private const string _animatorLookX = "LookX";
    private const string _animatorLookY = "LookY";
    private const string _animatorSpeed = "Speed";

    private void Awake()
    {
        _playerController = GetComponent<PlayerInteract>();
        _playerMove = GetComponent<PlayerMove>();
    }

    public void SetLookDirection(float x, float y)
    {
        _animator.SetFloat(_animatorLookX, x);
        _animator.SetFloat(_animatorLookY, y);
    }

    public void PlayMovingAnimation(float speed)
    {
        _animator.SetFloat(_animatorSpeed, speed);
    }
}
