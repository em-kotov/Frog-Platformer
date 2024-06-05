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

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        Jump();
        UpdateAnimation();
    }

    private void Run()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        _rigidbody.velocity = new Vector2(horizontalInput * _runSpeed, _rigidbody.velocity.y);

        UpdateFlip(horizontalInput);
    }

    private void UpdateFlip(float horizontalInput)
    {
        float minInput = 0.5f;

        if (horizontalInput > minInput && !_isFacingRight)
        {
            Flip();
            _isFacingRight = true;
        }
        else if (horizontalInput < -minInput && _isFacingRight)
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
        _animator.SetBool(IsGroundedName, IsGrounded());
    }

    private bool IsGrounded()
    {
        float distance = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, distance);

        return hit.collider != null;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(JumpKey) && IsGrounded())
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
