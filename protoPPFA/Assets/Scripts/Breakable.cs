using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<EquippedFaux>() && PlayerManager.Instance.HasBreakableFloor)
        {

            Break();

        }

    }

    private void Break()
    {

        Destroy(gameObject);

    }

}
