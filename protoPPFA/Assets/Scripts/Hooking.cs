using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hooking : MonoBehaviour
{

    [SerializeField] private float _hookSpeed = 0f;

    private bool _isHooked = false;

    private bool _spawned = false;

    private float _t = 0f;

    private float _prevFrame = 100f;

    public bool IsHooked
    {

        get
        {

            return _isHooked;

        }
        set
        {

            _isHooked = value;

        }

    }

    private GameObject _canvas = null;

    private GameObject _player;

    private void Awake()
    {

        _canvas = GetComponentInChildren<Canvas>().gameObject;

        _canvas.SetActive(false);

    }

    private void Update()
    {

        if (_isHooked)
        {

            _canvas.SetActive(true);

            if (!_spawned)
            {

                Vector3 hookPos = new Vector3(transform.position.x, transform.position.y, _canvas.transform.position.z);

                _canvas.transform.position = Vector3.Lerp(new Vector3(_player.transform.position.x + 0.005f * (transform.position - _canvas.transform.position).normalized.x, _player.transform.position.y + 0.005f, _canvas.transform.position.z), hookPos, _t);

                _t += Time.deltaTime * _hookSpeed;

                if (IsSuperior(_prevFrame, Vector3.Distance(_canvas.transform.position, hookPos), true))
                {

                    _spawned = true;

                }

                _prevFrame = Vector3.Distance(_canvas.transform.position, hookPos);

            }


            //_canvas.GetComponentInChildren<Image>().fillAmount = Mathf.InverseLerp(0, 4, _player.GetComponent<DistanceJoint2D>().distance);
            _canvas.GetComponentInChildren<Image>().fillAmount = Mathf.InverseLerp(0, 4, Vector3.Distance(_canvas.transform.position, _player.transform.position));

            _canvas.transform.LookAt(new Vector3(_player.transform.position.x, _player.transform.position.y, _canvas.transform.position.z), -Vector3.forward);

        }
        else
        {

            _canvas.SetActive(false);

            _spawned = false;

            _t = 0f;

            _prevFrame = 100f;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<RealMove>() != null/* && (transform.position.y - other.transform.position.y) > 0*/)
        {

            //_isHooked = true;

            _player = other.gameObject;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        //_isHooked = false;
        
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius);

    }

    private bool IsSuperior(float inferiorFloat, float superiorFloat)
    {

        if (superiorFloat > inferiorFloat)
        {

            return true;

        }
        else
        {

            return false;

        }

    }
    private bool IsSuperior(float inferiorFloat, float superiorFloat, bool isInclusive)
    {

        if (isInclusive)
        {

            if (superiorFloat >= inferiorFloat)
            {

                return true;

            }
            else
            {

                return false;

            }

        }
        else
        {

            if (superiorFloat > inferiorFloat)
            {

                return true;

            }
            else
            {

                return false;

            }

        }

    }

}
