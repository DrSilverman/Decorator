using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMap : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        PlayerManager.Instance.Maps += 1;

        Destroy(gameObject);

    }

}
