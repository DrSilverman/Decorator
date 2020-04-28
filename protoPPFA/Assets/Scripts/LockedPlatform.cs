using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPlatform : MonoBehaviour
{

    [SerializeField] private UI _UI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<EquippedFaux>())
        {

            Open();

        }

    }

    private void Open()
    {

        if (PlayerManager.Instance.HasKey > 0)
        {

            PlayerManager.Instance.HasKey--;

            _UI.update = true;

            Destroy(gameObject);

        }

    }

}
