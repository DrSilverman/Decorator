using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMove : MonoBehaviour
{

    #region 3D
    /*
    [SerializeField] private bool _isGrounded = false;

    public bool IsGrounded
    {

        get
        {

            return _isGrounded;

        }
        set
        {

            _isGrounded = value;

        }

    }

    [SerializeField] private float _impulse = 0f;

    private Vector2 _V0 = new Vector2(0, 0);
    private Vector2 _acceleration = new Vector2(0, 0);

    [SerializeField] private bool _descend = false;

    private void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0, 0);

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && _isGrounded)
        {

            Jump();

        }

        if ((GetComponent<Rigidbody>().velocity.y < -0.1 || Input.GetKeyUp(KeyCode.Joystick1Button0)) && !_descend)
        {

            Descend();

        }

        if (!_descend)
        {

            Physics.gravity = new Vector3(0, -22.22f, 0);

        }

        if (_isGrounded)
        {

            _descend = false;
            Physics.gravity = new Vector3(0, -22.22f, 0);

        }

    }

    private void Jump()
    {

        Physics.gravity = new Vector3(0, -22.22f, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 13.33f, 0), ForceMode.Impulse);

    }

    private void Descend()
    {

        Physics.gravity = new Vector3(0, -50, 0);
        _descend = true;

    }
    */

    #endregion 3D

    [Header("Walk")]
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _accelerationTime = 0f;
    [SerializeField] private float _deccelerationTime = 0f;

    private float _accelerationMultiplicator = 0f;
    private float _deccelerationMultiplicator = 0f;

    [Header("Jump")]
    [SerializeField] private float _gravity = 0f;
    [SerializeField] private float _highGravity = 0f;
    [SerializeField] private float _impulse = 0f;
    [SerializeField] private float _timeToGetControlBackHop = 0f;
    [SerializeField] private float _timeToGetControlBackDash = 0f;
    [SerializeField] private bool _isBlocked = false;
    [SerializeField] private float _immobilityTime = 0f;

    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private bool _isWalled = false;

    [Header("Animation")]
    [SerializeField] private Animator _anim = null;

    private Rigidbody2D _rb = null;

    private bool _FacingLeft = false;

    /*public Animator Anim
    {

        get
        {

            return _anim;

        }
        set
        {

            _anim = value;

        }

    }*/

    public bool IsGrounded
    {

        get
        {

            return _isGrounded;

        }
        set
        {

            _isGrounded = value;

        }

    }
    public bool IsWalled
    {

        get
        {

            return _isWalled;

        }
        set
        {

            _isWalled = value;

        }

    }

    private Vector2 _V0 = new Vector2(0, 0);
    private Vector2 _acceleration = new Vector2(0, 0);

    [SerializeField] private bool _descend = false;

    private float _Xvelocity = 0f;
    private float _testvelocity = 0f;

    private bool _isHopping = false;
    private bool _isDashing = false;

    private float _compteur = 0f;

    private int _dashRemaining = 1;

    private bool _dashActive = false;
    private bool _wallJumpActive = false;

    private bool _immobilityHopEngaged = false;
    private bool _immobilityDashEngaged = false;

    private float _hopSign = 0f;

    private void Awake()
    {

        Physics2D.gravity = new Vector2(0, _gravity);

        _rb = GetComponentInChildren<Rigidbody2D>();

        _accelerationMultiplicator = 1.25f / _accelerationTime / 10;
        _deccelerationMultiplicator = 1.25f / _deccelerationTime / 10;

        transform.position = new Vector3(global::PlayerManager.Instance.RespawnPosition.x, global::PlayerManager.Instance.RespawnPosition.y, transform.position.z);

    }

    private void OnEnable()
    {

        InputManager.Horizontal += Move;
        InputManager.JumpDown += Jump;
        InputManager.JumpUp += Descend;

        InputManager.Reset += ResetVelocity;
        
    }

    private void OnDisable()
    {

        InputManager.Horizontal -= Move;
        InputManager.JumpDown -= Jump;
        InputManager.JumpUp -= Descend;

        InputManager.Reset -= ResetVelocity;

        if (PlayerManager.Instance.HasDash)
        InputManager.DashDown -= Dash;

        if (PlayerManager.Instance.HasWallJump) { }
            InputManager.JumpDown -= WallJump;

    }

    private void Update()
    {

        if (PlayerManager.Instance.HasWallJump && !_wallJumpActive)
        {

            InputManager.JumpDown += WallJump;

            _wallJumpActive = true;

        }
        else
        {

            InputManager.JumpDown -= WallJump;

            _wallJumpActive = false;

        }

        if (PlayerManager.Instance.HasDash && !_dashActive)
        {
            
            InputManager.DashDown += Dash;

            _dashActive = true;

        }
        else
        {

            InputManager.DashDown -= Dash;

            _dashActive = false;

        }

        if (_isDashing)
        {

            _rb.velocity = new Vector2(30 * -transform.localScale.x, 0);

        }

        if (!_isDashing)
        {

            if (!_isHopping)
            {

                _rb.velocity = new Vector2(_Xvelocity, _rb.velocity.y);

            }

            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y + Physics2D.gravity.y * Time.deltaTime, -40, 100));

        }

        if (_rb.velocity.x != 0 && _isGrounded)
        {

            _anim.SetBool("_isWalking", true);

        }
        else
        {

            _anim.SetBool("_isWalking", false);

        }

        if (GetComponent<Rigidbody2D>().velocity.y < -0.1 && !_descend && !_isGrounded)
        {

            Descend(_highGravity);

        }

        if (!_descend)
        {

            Physics2D.gravity = new Vector2(0, _gravity);

        }

        if (_isGrounded)
        {

            _descend = false;
            Physics2D.gravity = new Vector2(0, _gravity);

            _dashRemaining = 1;

        }

        if (_isBlocked || _isHopping)
        {

            _compteur += Time.deltaTime;

            if (_compteur >= _timeToGetControlBackHop && _isHopping)
            {

                _isHopping = false;

                _compteur = 0f;

            }

            /*if (_compteur >= _timeToGetControlBackHop + _immobilityTime && _immobilityHopEngaged)
            {

                InputManager.Blockinput = false;

                _isBlocked = false;

                _immobilityHopEngaged = false;

                _compteur = 0f;

            }*/

            if (_compteur >= _timeToGetControlBackDash && _isDashing)
            {
                
                _isDashing = false;

                _immobilityDashEngaged = true;

            }

            if (_compteur >= _timeToGetControlBackDash + _immobilityTime && _immobilityDashEngaged)
            {

                InputManager.Blockinput = false;

                _isBlocked = false;

                _immobilityDashEngaged = false;

                _compteur = 0f;

            }

        }

    }

    public void Move(float value)
    {

        if (value > 0)
        {
            if (value != 0f && _Xvelocity < 1.25f * _speed * value)
            {

                _Xvelocity += (_accelerationMultiplicator * _speed * value) * 10 * Time.deltaTime;

            }

            if (_FacingLeft)
                Flip();

        }
        else if (value < 0)
        {
            if (value != 0f && _Xvelocity > 1.25f * _speed * value)
            {

                _Xvelocity += (_accelerationMultiplicator * _speed * value) * 10 * Time.deltaTime;

            }

            if (!_FacingLeft)
                Flip();

        }
        if (value == 0f)
        {
            if (_Xvelocity > 0f)
            {

                _Xvelocity -= (_deccelerationMultiplicator * _speed) * 10 * Time.deltaTime;

                if (_Xvelocity < 0f)
                    _Xvelocity = 0;

            }
            else
            {

                _Xvelocity += (_deccelerationMultiplicator * _speed) * 10 * Time.deltaTime;

                if (_Xvelocity > 0f)
                    _Xvelocity = 0;

            }
        }

    }

    public void Jump()
    {

        if (_isGrounded)
        {

            Physics2D.gravity = new Vector2(0, _gravity);
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(0, _impulse), ForceMode2D.Impulse);

        }

    }

    public void WallJump()
    {

        if (!_isGrounded && _isWalled)
        {

            _descend = false;

            Physics2D.gravity = new Vector2(0, _gravity);
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(25 * transform.localScale.x, _impulse), ForceMode2D.Impulse);

            _isHopping = true;

        }

    }

    public void Dash()
    {

        if (_dashRemaining > 0)
        {

            int index = 1;

            if (_FacingLeft)
                index = -1;

            _isDashing = true;
            _isBlocked = true;

            InputManager.Blockinput = true;

            /*_rb.velocity = new Vector2(0, 0);

            _rb.AddForce(new Vector2(15 * index, 0), ForceMode2D.Impulse);*/

            _dashRemaining--;

        }

    }

    public void Descend()
    {

        if (!_descend)
            Descend(_highGravity);

    }

    private void Descend(float gravity)
    {

        Physics2D.gravity = new Vector2(0, gravity);
        _descend = true;

    }

    private void ResetVelocity()
    {

        _Xvelocity = 0;

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _FacingLeft = !_FacingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = /*_anim.gameObject.*/transform.localScale;
        theScale.x *= -1;
        /*_anim.gameObject.*/transform.localScale = theScale;
    }

}
