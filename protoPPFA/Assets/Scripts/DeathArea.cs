using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{

    private void Awake()
    {
        
        if (PlayerManager.Instance.HasMap)
        {

            transform.GetChild(0).gameObject.SetActive(true);

        }

    }

}
