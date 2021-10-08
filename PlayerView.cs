using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PlayerInteract _playerController;
    private PlayerMove _playerMove;


    private void Awake()
    {
        _playerController = GetComponent<PlayerInteract>();
        _playerMove = GetComponent<PlayerMove>();
    }

    public void SetLookDirection(float x, float y)
    {
        _animator.SetFloat("LookX", x);
        _animator.SetFloat("LookY", y);
    }

    public void PlayMovingAnimation(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
