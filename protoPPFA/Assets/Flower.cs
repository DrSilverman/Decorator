using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    [SerializeField] private UI _ui = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<EquippedFaux>())
        {

            PlayerManager.Instance.Flowers += 1;

            _ui.update = true;

            Destroy(gameObject);

        }

    }
}
