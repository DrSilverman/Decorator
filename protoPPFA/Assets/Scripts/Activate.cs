using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{

    [SerializeField] private bool _isMoving;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<EquippedFaux>())
        {

            if (_isMoving && PlayerManager.Instance.HasMovingPlatform)
                transform.parent.GetComponent<MovingPlateform>().Move();

            else if (PlayerManager.Instance.HasActivablePlatform)
                transform.parent.GetComponent<ActivablePlateform>().Activate();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_isMoving)
            transform.parent.GetComponent<MovingPlateform>().FillPlayer(collision.gameObject.transform);

        else
            transform.parent.GetComponent<ActivablePlateform>().FillPlayer(collision.gameObject.transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (_isMoving)
            transform.parent.GetComponent<MovingPlateform>().ClearPlayer();

        else
            transform.parent.GetComponent<ActivablePlateform>().ClearPlayer();

    }

}
