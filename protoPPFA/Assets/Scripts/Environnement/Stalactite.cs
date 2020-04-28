using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{

    [SerializeField] private GameObject _player = null;

    private Rigidbody2D _falling = null;

    // Start is called before the first frame update
    void Start()
    {

        _falling = GetComponentInChildren<Rigidbody2D>();

        _falling.simulated = false;

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 10);

        if (hit.collider != null && hit.collider.gameObject == _player)
        {

            if (_falling != null)
                _falling.simulated = true;

        }

    }

    private void OnDrawGizmos()
    {

        //Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 10, transform.position.z));

    }

}
