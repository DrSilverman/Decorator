using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] private GameObject _player = null;
    [SerializeField] private Transform[] _raycastOrigins = new Transform[2];
    [SerializeField] private Transform[] _raycastTopOrigins = new Transform[4];
    [SerializeField] private Transform[] _raycastSideOrigins = new Transform[2];
    [SerializeField] private float _distRaycast = 0f;

    private RealMove _playerMove = null;

    public GameObject _currentRoom = null;

    // Start is called before the first frame update
    void Start()
    {

        _playerMove = _player.GetComponent<RealMove>();

    }

    // Update is called once per frame
    void Update()
    {

                Bot();
                Side();

    }

    private void Bot()
    {

        RaycastHit2D hit = Physics2D.Raycast(_raycastOrigins[0].position, -Vector3.up, _distRaycast);
        RaycastHit2D hit2 = Physics2D.Raycast(_raycastOrigins[1].position, -Vector3.up, _distRaycast);

        if ((hit.collider != null && hit.collider.gameObject != _player) || (hit2.collider != null && hit2.collider.gameObject != _player))
        {

            _playerMove.IsGrounded = true;

        }
        else
        {
            _playerMove.IsGrounded = false;

        }

    }

    private void Side()
    {

        RaycastHit2D sideHit = Physics2D.Raycast(_raycastSideOrigins[0].position, -Vector3.right, _distRaycast);
        RaycastHit2D sideHit2 = Physics2D.Raycast(_raycastSideOrigins[1].position, Vector3.right, _distRaycast);

        /*RaycastHit2D sideHit3 = Physics2D.Raycast(_raycastSideOrigins[2].position, -Vector3.right, _distRaycast);
        RaycastHit2D sideHit4 = Physics2D.Raycast(_raycastSideOrigins[3].position, Vector3.right, _distRaycast);*/



        if ((sideHit.collider != null && sideHit.collider.gameObject != _player) || (sideHit2.collider != null && sideHit2.collider.gameObject != _player)/* || (sideHit3.collider != null && sideHit3.collider.gameObject != _player) || (sideHit4.collider != null && sideHit4.collider.gameObject != _player)*/)
        {

            _playerMove.IsWalled = true;

        }
        else
        {

            _playerMove.IsWalled = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.GetComponent<CameraBehaviour>() != null)
        {

            _currentRoom = other.gameObject;

        }

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        for (int i = 0; i < _raycastOrigins.Length; i++)
        {

            Gizmos.DrawLine(_raycastOrigins[i].position, new Vector3(_raycastOrigins[i].position.x, _raycastOrigins[i].position.y - _distRaycast, _raycastOrigins[i].position.z));

        }
        for (int i = 0; i < /*_raycastSideOrigins.Length*/2; i++)
        {

            Gizmos.DrawLine(_raycastSideOrigins[i].position, new Vector3(_raycastSideOrigins[i].position.x - _distRaycast, _raycastSideOrigins[i].position.y, _raycastSideOrigins[i].position.z));

        }

    }

}
