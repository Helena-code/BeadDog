using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 LookDirection  // зачем?
    {
        get { return _lookDirection; }
    }
    
    [SerializeField] private float _speed;
    [SerializeField] private FixedJoystick _fixedJoystick;

    private PlayerInteract _playerController;
    private PlayerView _playerView;
    private float _vertical;
    private float _horizontal;
    private Vector2 _lookDirection = new Vector2(1, 0);
    private Transform _transform;


    private void Awake()
    {
        _playerController = GetComponent<PlayerInteract>();
        _playerView = GetComponent<PlayerView>();
        _transform = transform;
    }

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        _horizontal = Input.GetAxis("_horizontal");                             
        _vertical = Input.GetAxis("_vertical");

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        _horizontal = _fixedJoystick.Horizontal;
        _vertical = _fixedJoystick.Vertical;

#endif
        Vector2 move = new Vector2(_horizontal, _vertical);                     // создаю вектор, в который записываю данные о задаваемом положении игрока
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))  // сравнение х или y c 0 через эту функцию, потому что через == не точно
        {
            _lookDirection.Set(move.x, move.y);
            _lookDirection.Normalize();
            //Debug.Log("_lookDirection " + _lookDirection);
        }
        _playerView.SetLookDirection(_lookDirection.x, _lookDirection.y);
        _playerView.PlayMovingAnimation(move.magnitude);
        Debug.Log("" + move.magnitude);
                          
        if (move.magnitude > 0.1)
        {
            //audioSource.PlayOneShot(clip);
        }

        _transform.Translate(move * _speed * Time.deltaTime);
    }
}
