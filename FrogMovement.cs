using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class FrogMovement : MonoBehaviour
{
    private readonly string _commandHorizontal = "Horizontal";
    private readonly string _commandSpeed = "Speed";
    private readonly string _commandIsGrounded = "IsGrounded";
    private readonly KeyCode _jumpKey = KeyCode.Space;

    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _canJump = false;
    private float _direction = 0f;

    public bool IsFacingRight { get; private set; } = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction = Input.GetAxis(_commandHorizontal);

        if (Input.GetKeyDown(_jumpKey) && IsGrounded())
            _canJump = true;
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
        UpdateAnimation();
    }

    private bool IsGrounded()
    {
        float distance = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, distance);

        return hit.collider != null;
    }

    private void Run()
    {
        _rigidbody.velocity = new Vector2(_direction * _runSpeed, _rigidbody.velocity.y);

        UpdateFlip();
    }

    private void UpdateFlip()
    {
        float minInput = 0.5f;

        if (_direction > minInput && !IsFacingRight)
        {
            Flip();
            IsFacingRight = true;
        }
        else if (_direction < -minInput && IsFacingRight)
        {
            Flip();
            IsFacingRight = false;
        }
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void UpdateAnimation()
    {
        float speed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(_commandSpeed, speed);
        _animator.SetBool(_commandIsGrounded, IsGrounded());
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
