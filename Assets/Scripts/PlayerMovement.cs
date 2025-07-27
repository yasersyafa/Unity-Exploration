using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _gravity = -5f;
    [SerializeField] private float _rotateSpeed = 0.1f;
    [SerializeField] private GameController _gameController;
    #endregion

    private Vector3 _input;
    private CharacterController _characterController;
    private Vector3 _velocity;
    private int _isWalking;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isWalking = Animator.StringToHash("IsWalking");
    }

    // Update is called once per frame
    void Update()
    {
        HandleGroundCheck();

        HandleInput();

        HandleLookRotation();

        HandleAnimation();

        HandleMove();
    }

    private void HandleGroundCheck()
    {
        bool isGrounded = _characterController.isGrounded;
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }

        if (!isGrounded)
        {
            _velocity.y = _gravity * Time.deltaTime;
        }
    }

    private void HandleAnimation()
    {
        bool isWalking = IsWalking();
        _playerAnimator.SetBool(_isWalking, isWalking);
    }

    private bool IsWalking()
    {
        return _input != Vector3.zero;
    }

    private void HandleInput()
    {
        Vector2 input = _gameController.GetInputActions().Player.Move.ReadValue<Vector2>();
        _input = new(input.x, 0, input.y);
    }

    private void HandleLookRotation()
    {
        if (_input == Vector3.zero) return;

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, -135, 0));
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(_input);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed);
    }

    private void HandleMove()
    {
        Vector3 move = _input.magnitude * _moveSpeed * Time.deltaTime * transform.forward + _velocity;
        if(IsWalking()) _characterController.Move(move);
    }
}
