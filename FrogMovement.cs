using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Speed = "Speed";
    private readonly string IsGroundedName = "IsGrounded";
    private readonly KeyCode JumpKey = KeyCode.Space;

    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isFacingRight = true;
    private bool _canJump = false;
    private bool _isGrounded = false;
    private float _direction = 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JumpKey) && _isGrounded)
        {
            _canJump = true;
        }
    }

    private void FixedUpdate()
    {
        DetectGround();
        Run();
        Jump();
        UpdateAnimation();
    }

    private void DetectGround()
    {
        float distance = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, distance);

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void Run()
    {
        _rigidbody.velocity = new Vector2(_direction * _runSpeed, _rigidbody.velocity.y);

        UpdateFlip();
    }

    private void UpdateFlip()
    {
        float minInput = 0.5f;

        if (_direction > minInput && !_isFacingRight)
        {
            Flip();
            _isFacingRight = true;
        }
        else if (_direction < -minInput && _isFacingRight)
        {
            Flip();
            _isFacingRight = false;
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void UpdateAnimation()
    {
        float speed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(Speed, speed);
        _animator.SetBool(IsGroundedName, _isGrounded);
    }

    private void Jump()
    {
        if (_canJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _canJump = false;
        }
    }
}
