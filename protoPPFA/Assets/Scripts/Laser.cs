using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool _isActive = true;

    private BoxCollider2D _box = null;
    private MeshRenderer _mesh = null;

    private void Awake()
    {

        _box = GetComponent<BoxCollider2D>();
        _mesh = GetComponent<MeshRenderer>();

    }

    void Update()
    {
        
        if (_isActive && PlayerManager.Instance.HasIgnorePlatform)
        {

            _box.enabled = false;
            _mesh.enabled = false;

        }
        else
        {

            _box.enabled = true;
            _mesh.enabled = true;

        }
        

    }
}
