using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateform : MonoBehaviour
{

    [SerializeField] private bool _horizontal = false;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private Vector2 _size = Vector2.zero;

    private Vector3 _dir = Vector3.zero;

    private Transform _plateform = null;

    private Transform _player = null;
    private Rigidbody2D _playerRb = null;

    private void Awake()
    {

        _plateform = transform.GetChild(0).transform;


    }

    private void Update()
    {

        _plateform.transform.Translate(_dir);

        if (_player != null)
        {

            _player.transform.Translate(_dir);
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, 0);

        }

        switch (_horizontal)
        {

            case (true):

                if (Mathf.Abs(transform.position.x - _plateform.transform.position.x) > _size.x / 2)
                {

                    _speed *= -1;


                }

                _dir = new Vector3(_speed, 0, 0);

                break;

            case (false):

                if (Mathf.Abs(transform.position.y - _plateform.transform.position.y) > _size.y / 2)
                {

                    _speed *= -1;


                }

                _dir = new Vector3(0, _speed, 0);

                break;

        }

    }

    public void Move()
    {

        _horizontal = !_horizontal;

    }

    public void FillPlayer(Transform other)
    {

        _player = other;
        _playerRb = _player.GetComponent<Rigidbody2D>();

    }

    public void ClearPlayer()
    {

        _player = null;
        _playerRb = null;

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_size.x, _size.y, 0));

    }

}
