using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(GetComponent<Rigidbody2D>());

        foreach (Collider2D collider in GetComponents<BoxCollider2D>())
        {

            Destroy(collider);

        }

    }
}
