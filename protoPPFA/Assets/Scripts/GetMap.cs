using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMap : MonoBehaviour
{

    [SerializeField] private map _player = null;

    private bool _trigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<map>())
        {
            
            PlayerManager.Instance.Maps += 1;
            transform.GetChild(0).gameObject.SetActive(true);
            _trigger = true;

        }
        
        if (other.GetComponent<EquippedFaux>())
        {

                if (!_trigger)
            PlayerManager.Instance.Maps += 1;

            Destroy(gameObject);

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<map>())
        {
            
            PlayerManager.Instance.Maps -= 1;
            transform.GetChild(0).gameObject.SetActive(false);
            _trigger = false;
        }

    }

}
