using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{

    [SerializeField] private GameObject _player = null;
    [SerializeField] private Transform _target = null;

    private bool _canTP = true;

    public bool CanTP
    {

        get
        {

            return _canTP;

        }
        set
        {

            _canTP = value;

        }

    }

    private void Start()
    {
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == _player && _canTP)
        {

            other.gameObject.transform.position = _target.transform.position;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        _canTP = true;

    }

}
