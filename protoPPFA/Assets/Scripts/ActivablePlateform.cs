using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivablePlateform : MonoBehaviour
{

    [SerializeField] private bool _running = false;
    [SerializeField] private bool _horizontal = false;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private Vector2 _size = Vector2.zero;

    private Vector3 _dir = Vector3.zero;

    private Transform _plateform = null;

    private Transform _player = null;

    private float _actualSpeed = 0;

    private void Awake()
    {

        _plateform = transform.GetChild(0).transform;

    }

    private void Update()
    {

        _plateform.transform.Translate(_dir);

        if (_player != null)
            _player.transform.Translate(_dir);

        switch (_horizontal)
        {

            case (true):

                if (_plateform.transform.localPosition.x <= _size.y || _plateform.transform.localPosition.x >= _size.x)
                {

                    _speed *= -1;


                }

                if (_running)
                    _actualSpeed = _speed;
                else
                    _actualSpeed = 0f;

                _dir = new Vector3(_actualSpeed, 0, 0);

                break;

            case (false):

                if (_plateform.transform.localPosition.y <= _size.y || _plateform.transform.localPosition.y >= _size.x)
                {

                    _speed *= -1;


                }

                if (_running)
                    _actualSpeed = _speed;
                else
                    _actualSpeed = 0f;

                _dir = new Vector3(0, _actualSpeed, 0);

                break;

        }

    }

    public void Activate()
    {

        _running = !_running;

    }

    public void FillPlayer(Transform other)
    {

        _player = other;

    }

    public void ClearPlayer()
    {

        _player = null;

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        if (_horizontal)
            Gizmos.DrawLine(new Vector2(transform.position.x + _size.x, transform.position.y), new Vector2(transform.position.x + _size.y, transform.position.y));

        else
            Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + _size.x), new Vector2(transform.position.x, transform.position.y + _size.y));

    }

}
