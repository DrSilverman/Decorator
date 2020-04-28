using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    private bool _died = false;

    private CameraBehaviour _other = null;

    private void Update()
    {

        if (PlayerManager.Instance.CanRespawn)
        {

            Respawn(PlayerManager.Instance.RespawnPosition);

            PlayerManager.Instance.CanRespawn = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Falling>() || other.GetComponent<kill>())
        {

            if (!_died)
            {

                Die();

                _died = true;

            }

        }

        if (other.GetComponent<CameraBehaviour>())
        {

            _other = other.GetComponent<CameraBehaviour>();

        }

    }

    private void Die()
    {

        RealMove _move = GetComponent<RealMove>();

        InputManager.Horizontal -= _move.Move;
        InputManager.JumpDown -= _move.Jump;
        InputManager.JumpUp -= _move.Descend;

        GetComponent<BoxCollider2D>().enabled = false;

        SceneManager.LoadScene("Death", LoadSceneMode.Additive);

    }

    public void Respawn(Vector3 position)
    {

        RealMove _move = GetComponent<RealMove>();

        _other.Triggered = false;

        transform.position = new Vector3(position.x, position.y, transform.position.z);

        InputManager.Horizontal += _move.Move;
        InputManager.JumpDown += _move.Jump;
        InputManager.JumpUp += _move.Descend;

        GetComponent<BoxCollider2D>().enabled = true;

        _died = false;

    }

}
