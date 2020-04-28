using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private Transform _faux = null;
    [SerializeField] private Transform _origin = null;
    [SerializeField] private Transform _target = null;
    [SerializeField] private float _attackSpeed = 7;

    [Header("Animation")]
    [SerializeField] private Animator _anim = null;

    [Header("UI")]
    [SerializeField] private GameObject _shadowCanvas = null;
    [SerializeField] private GameObject _shadow = null;
    [SerializeField] private GameObject _fauxShadow = null;
    [SerializeField] private GameObject _all = null;
    [SerializeField] private GameObject _text = null;

    private bool _doIt = false;

    private bool _weaponTaken = false;
    private bool _put = false;

    private bool _attackEngaged = false;

    private float _t = 0;

    private AudioSource _audio = null;

    private bool _lateAwake = false;

    public Transform Faux
    {

        set
        {

            _faux = value;

        }

    }
    public Transform Origin
    {

        set
        {

            _origin = value;

        }

    }
    public Transform Target
    {

        set
        {

            _target = value;

        }

    }
    public Animator Anim
    {

        set
        {

            _anim = value;

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

    public bool WeaponTaken
    {

        set
        {

            _weaponTaken = value;

        }

    }

    private void OnEnable()
    {

        InputManager.AttackDown += EngageAttack;

    }

    private void OnDisable()
    {

        InputManager.AttackDown -= EngageAttack;

    }

    private void Start()
    {

        _audio = _faux.gameObject.GetComponent<AudioSource>();

    }

    private void Update()
    {
        
        if (_weaponTaken && !_put)
        {

            InputManager.AttackDown += EngageAttack;

            _put = true;

        }
        else if (!_weaponTaken && _put)
        {

            InputManager.AttackDown -= EngageAttack;

            _put = false;

        }

        if (_attackEngaged)
        {

            PerformAttack();

        }

    }

    public void EngageAttack()
    {

        if (GetComponent<hook>() && !_attackEngaged && (!GetComponent<hook>().Triggered || (GetComponent<hook>() && GetComponent<hook>().Triggered && GetComponent<RealMove>().IsGrounded)) || !GetComponent<hook>())
        {

            _t = 0;

            _attackEngaged = true;

            _faux.gameObject.SetActive(true);

            _anim.gameObject.SetActive(true);

            _anim.SetBool("_isAttacking", true);

            _audio.Play();

        }
    }

    private void PerformAttack()
    {

        _faux.rotation = Quaternion.Lerp(_origin.rotation, _target.rotation, _t);

        _t += Time.deltaTime * _attackSpeed;

        if (_faux.rotation.z * transform.localScale.x <= _target.rotation.z * transform.localScale.x)
        {

            _attackEngaged = false;

            _anim.SetBool("_isAttacking", false);

            _faux.gameObject.SetActive(false);

            _anim.gameObject.SetActive(false);

        }

    }

    public void Cutscene()
    {

        StartCoroutine(CutsceneFaux());

    }

    private IEnumerator CutsceneFaux()
    {

        _text.SetActive(true);
        _shadowCanvas.SetActive(true);
        InputManager.Blockinput = true;

        InputManager.ResetPlayer();

        yield return new WaitForSeconds(0.5f);

        _shadow.SetActive(false);

        _fauxShadow.SetActive(true);

        InputManager.Submit += CloseCutscene;

    }

    private void CloseCutscene()
    {

        _shadowCanvas.SetActive(false);
        _text.SetActive(false);

        _shadow.SetActive(true);

        _fauxShadow.SetActive(false);

        InputManager.Submit -= CloseCutscene;
        InputManager.Blockinput = false;

    }

}
