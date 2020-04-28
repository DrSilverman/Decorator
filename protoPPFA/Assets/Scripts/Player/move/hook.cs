using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{

    [SerializeField] private float _adjustSpeed = 4f;

    [Header("UI")]
    [SerializeField] private GameObject _shadowCanvas = null;
    [SerializeField] private GameObject _shadow = null;
    [SerializeField] private GameObject _fauxShadow = null;
    [SerializeField] private GameObject _all = null;
    [SerializeField] private GameObject _text = null;

    private DistanceJoint2D _joint = null;

    private bool _triggered = false;

    private GameObject _trigger = null;

    private Hooking _hook = null;

    private Rigidbody2D _rb = null;

    public bool Triggered
    {

        get
        {

            return _triggered;

        }

    }

    public GameObject ShadowCanvas
    {

        set
        {

            _shadowCanvas = value;

        }

    }
    public GameObject Shadow
    {

        set
        {

            _shadow = value;

        }

    }
    public GameObject FauxShadow
    {

        set
        {

            _fauxShadow = value;

        }

    }
    public GameObject All
    {

        set
        {

            _all = value;

        }

    }
    public GameObject Text
    {

        set
        {

            _text = value;

        }

    }

    private void OnEnable()
    {

        InputManager.AttackDown += AddJoint; ;
        InputManager.AttackUp += RemoveJoint;
        InputManager.Vertical += Adjust;

    }

    private void OnDestroy()
    {

        InputManager.AttackDown -= AddJoint; ;
        InputManager.AttackUp -= RemoveJoint;
        InputManager.Vertical -= Adjust;

    }

    private void Awake()
    {

        _rb = GetComponent<Rigidbody2D>();

    }

    private void AddJoint()
    {
        if (_triggered && !GetComponent<RealMove>().IsGrounded && (_trigger.transform.position.y - transform.position.y) > 0)
        {

            _joint = gameObject.AddComponent<DistanceJoint2D>();

            _joint.connectedBody = _trigger.GetComponent<Rigidbody2D>();
            _joint.autoConfigureDistance = false;
            _joint.distance = Mathf.Clamp((_trigger.transform.position - transform.position).magnitude, 0.5f, 4);

            if (_hook != null)
                    _hook.IsHooked = true;

        }

    }

    private void RemoveJoint()
    {
        
        if (_hook != null)
            _hook.IsHooked = false;

            Destroy(_joint);

    }

    private void Adjust(float value)
    {

        if (_hook!= null && _hook.IsHooked && _rb.velocity.x == 0)
        {

            _joint.distance = Mathf.Clamp( _joint.distance + value * Time.deltaTime * _adjustSpeed, 0.5f, 4);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<Hooking>() != null)
        {

            if (_trigger == null)
                _trigger = other.gameObject;

            _triggered = true;

            if (_hook == null)
                _hook = other.gameObject.GetComponentInChildren<Hooking>();

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<Hooking>() != null)
        {

            _trigger = null;

            _triggered = false;

            if ( _hook != null && !_hook.IsHooked)
                _hook = null;

        }

    }

    public void Cutscene()
    {

        StartCoroutine(CutsceneHook());

    }

    private IEnumerator CutsceneHook()
    {

        _text.SetActive(true);
        _shadowCanvas.SetActive(true);
        _fauxShadow.SetActive(true);

        InputManager.Blockinput = true;

        InputManager.ResetPlayer();

        yield return new WaitForSeconds(0.5f);

        _fauxShadow.SetActive(false);

        _all.SetActive(true);

        InputManager.Submit += CloseCutscene;

    }

    private void CloseCutscene()
    {

        _shadowCanvas.SetActive(false);
        _text.SetActive(false);

        _fauxShadow.SetActive(true);

        _all.SetActive(false);

        InputManager.Submit -= CloseCutscene;

        InputManager.Blockinput = false;

    }

}
