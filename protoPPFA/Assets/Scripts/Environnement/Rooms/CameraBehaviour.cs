using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _camera = null;

    [SerializeField] private bool _longRoom = false;

    [SerializeField] private Transform[] _edges = new Transform[2];

    private bool _triggered = false;

    public bool Triggered
    {

        get
        {

            return _triggered;

        }
        set
        {

            _triggered = value;

        }

    }

    private void Update()
    {
        
        if (_longRoom && _triggered)
        {

            if ((_edges[0].position.y) < (_edges[1].position.y))
            {

                if (_player.transform.position.y > _edges[0].position.y && _player.transform.position.y < _edges[1].position.y)
                {

                    _camera.transform.position = new Vector3(transform.position.x, _player.transform.position.y, _camera.transform.position.z);

                }

            }
            else
            {

                if (_player.transform.position.y > _edges[1].position.y && _player.transform.position.y < _edges[0].position.y)
                {

                    _camera.transform.position = new Vector3(transform.position.x, _player.transform.position.y, _camera.transform.position.z);

                }

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == _player)
        {
            _triggered = true;
            if (!_longRoom)
                _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);
            else
            {

                if (Mathf.Abs(_edges[0].position.y - _player.transform.position.y) < Mathf.Abs(_edges[1].position.y - _player.transform.position.y))
                {
                    
                    _camera.transform.position = new Vector3(transform.position.x, _edges[0].transform.position.y, _camera.transform.position.z);

                }
                else
                {

                    _camera.transform.position = new Vector3(transform.position.x, _edges[1].transform.position.y, _camera.transform.position.z);

                }

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        _triggered = false;

    }

}
