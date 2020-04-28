using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;

    public static GameManager Instance
    {

        get
        {

            if (_instance == null)
            {

                GameManager[] instance = FindObjectsOfType<GameManager>();

                if (instance.Length == 0)
                {

                    Debug.LogError("There is no GameManager running in the scene");

                    return null;

                }
                if (instance.Length > 1)
                {

                    Debug.LogError("There is more than one GameManager running in the scene");

                    return null;

                }

                _instance = instance[0];

            }

            return _instance;

        }

    }

    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _mapCanvas = null;

    [Header("ShadowCanvas")]
    [SerializeField] private GameObject _shadowCanvas = null;
    [SerializeField] private GameObject _shadow = null;
    [SerializeField] private GameObject _fauxShadow = null;
    [SerializeField] private GameObject _all = null;
    [SerializeField] private GameObject _text = null;

    [Header("Attack")]
    [SerializeField] private Transform _faux = null;
    [SerializeField] private Transform _origin = null;
    [SerializeField] private Transform _target = null;
    [SerializeField] private Animator _anim = null;

    public GameObject Player
    {

        get
        {

            return _player;

        }

    }
    public GameObject MapCanvas
    {

        get
        {

            return _mapCanvas;

        }

    }
    public GameObject ShadowCanvas
    {

        get
        {

            return _shadowCanvas;

        }

    }
    public GameObject Shadow
    {

        get
        {

            return _shadow;

        }

    }
    public GameObject FauxShadow
    {

        get
        {

            return _fauxShadow;

        }

    }
    public GameObject All
    {

        get
        {

            return _all;

        }

    }
    public GameObject Text
    {

        get
        {

            return _text;

        }

    }

    public Transform Faux
    {

        get
        {

            return _faux;

        }

    }
    public Transform Origin
    {

        get
        {

            return _origin;

        }

    }
    public Transform Target
    {

        get
        {

            return _target;

        }

    }
    public Animator Anim
    {

        get
        {

            return _anim;

        }

    }

}
