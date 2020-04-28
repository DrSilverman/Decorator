using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public List<GameObject> _keys = new List<GameObject>();
    public List<GameObject> _flowers = new List<GameObject>();

    private bool _update = false;

    public bool update
    {

        set
        {

            _update = value;

        }

    }

    private void Update()
    {
       

        if (_update)
        {

            foreach (GameObject flower in _flowers)
            {

                if (flower.activeInHierarchy)
                {

                    flower.SetActive(false);

                }

            }

            for (int i = 0; i < _flowers.Count; i++)
            {

                if (i <= PlayerManager.Instance.Flowers - 1)
                {

                    _flowers[i].SetActive(true);

                }

            }

            foreach (GameObject key in _keys)
            {
                
                if (key.activeInHierarchy)
                {

                    key.SetActive(false);

                }

            }

            for (int i = 0; i < _keys.Count; i++)
            {

                if (i <= PlayerManager.Instance.HasKey - 1)
                {

                    _keys[i].SetActive(true);

                }

            }

            _update = false;

        }

    }

}
