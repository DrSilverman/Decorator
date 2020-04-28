using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{

    [SerializeField] private UI _UI;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<RealMove>())
        {

            PlayerManager.Instance.HasKey++;

            _UI.update = true;

            Destroy(gameObject);

        }

    }

}
