using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelTP : MonoBehaviour
{

    [SerializeField] private GameObject _player = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == _player)
        {

            transform.parent.GetComponentInChildren<TP>().CanTP = false;

        }

    }

}
