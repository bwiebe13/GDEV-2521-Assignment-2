using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _input;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravityMagnitude = 9.81f;
    private float _playerMass = 1f;
    public float PlayerMass
    {
        get { return _playerMass; }
        set { _playerMass = value; }
    }
    private Vector3 _velocity = Vector3.zero;
    private Rigidbody _rb;

    private enum PlayerState
    {
        Idle,
        Moving,
        Jumping
    }
    private PlayerState _currentState = PlayerState.Idle;
    void Awake()
    {
        _input = new InputSystem_Actions();
        _rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.mass = _playerMass;
        Vector3 gravityForce = Physics3D.CalculateNetForce(_playerMass, Physics3D.CalculateGravity(_gravityMagnitude));
        Vector2 moveInput = _input.Player.Move.ReadValue<Vector2>();
        if(moveInput == Vector2.zero && _currentState != PlayerState.Jumping)
        {
            _currentState = PlayerState.Idle;
        }
        else if(moveInput != Vector2.zero && _currentState != PlayerState.Jumping)
        {
            _currentState = PlayerState.Moving;
        }
        if (_input.Player.Jump.WasPressedThisFrame() && _currentState != PlayerState.Jumping)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            _currentState = PlayerState.Jumping;
        }
        Debug.Log("Current State: " + _currentState);
        switch (_currentState)
        {
            case PlayerState.Idle:
                _velocity = Vector3.zero;
                _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, 0);
                break;
            case PlayerState.Moving:
                _velocity = Physics3D.CalculateVelocity(new Vector3(moveInput.x * _moveSpeed, 0, moveInput.y * _moveSpeed), Mathf.Clamp(1 / Time.deltaTime, 0.01f, 1));
                _rb.AddForce(_velocity, ForceMode.VelocityChange);
                _rb.linearVelocity = new Vector3(Mathf.Clamp(_rb.linearVelocity.x, -_moveSpeed, _moveSpeed), _rb.linearVelocity.y, Mathf.Clamp(_rb.linearVelocity.z, -_moveSpeed, _moveSpeed));
                break;
        }
        _rb.AddForce(gravityForce, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _currentState = PlayerState.Idle;
        }
    }
}