using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{

    [SerializeField] private GameObject _canvas = null;
    [SerializeField] private GameObject[] _icons = null;

    private bool _mapped = false;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

            InputManager.MapDown -= ShowMap;
            InputManager.MapUp -= HideMap;

    }

    private void Update()
    {
        if (PlayerManager.Instance.Flowers != 0)
        {

            PlayerManager.Instance.HasFlower = true;

        }
        else
        {

            PlayerManager.Instance.HasFlower = false;

        }

        if (PlayerManager.Instance.Maps != 0)
        {

            PlayerManager.Instance.HasMap = true;

        }
        else
        {

            PlayerManager.Instance.HasMap = false;

        }

        for (int i = 0; i < 2; i++)
        {

            _icons[i].SetActive(false);

        }

        for (int i = 0; i < PlayerManager.Instance.Maps; i++)
        {

            _icons[i].SetActive(true);

        }
        
        if (PlayerManager.Instance.HasMap && !_mapped)
        {

            InputManager.MapDown += ShowMap;
            InputManager.MapUp += HideMap;

            _mapped = true;

        }
        if (!PlayerManager.Instance.HasMap && _mapped)
        {


            if (!_canvas.activeInHierarchy)
            {

                InputManager.MapDown -= ShowMap;

                InputManager.MapUp -= HideMap;

                _mapped = false;

            }

        }

    }

    public void ShowMap()
    {

        _canvas.SetActive(true);

    }

    public void HideMap()
    {

        _canvas.SetActive(false);

    }

}
