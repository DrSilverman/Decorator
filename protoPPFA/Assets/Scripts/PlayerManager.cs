using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager _instance;

    public static PlayerManager Instance
    {

        get
        {

            if (_instance == null)
            {

                PlayerManager[] instances = FindObjectsOfType<PlayerManager>();

                if (instances.Length == 0)
                {

                    Debug.LogError("There is no PlayerManager running in the scene");

                    return null;

                }
                if (instances.Length > 1)
                {

                    Debug.LogErrorFormat("There are {0} PlayerManager running in the scene", instances.Length);

                    return null;

                }

                _instance = instances[0];

            }

            return _instance;

        }

    }

    [SerializeField] private Transform _playerStart = null;

    public List<Vector3> _respawnPlaces;

    private int _nbTotem = 0;
    //private List<Vector3> _respawnPlaces;
    private Vector3 _respawnPosition;// = new Vector3(2.73f, 3.37f, 0);
    private bool _canRespawn = false;
    private bool _hasMap = false;
    private bool _hasFlower = false;
    private int _maps = 0;
    private int _flowers = 0;

    [Header("Upgrades (in order)")]
    [SerializeField] private bool _hasAttack = false;
    [SerializeField] private bool _hasGrapling = false;
    [SerializeField] private bool _hasDash = false;
    [SerializeField] private bool _hasMovingPlatform = false;
    [SerializeField] private bool _hasWallJump = false;
    [SerializeField] private bool _hasActivablePlatform = false;
    [SerializeField] private bool _hasIgnorePlatform = false;
    [SerializeField] private bool _hasBreakableFloor = false;

    private int _hasKey = 0;

    public int NbTotem
    {

        get
        {

            return _nbTotem;

        }
        set
        {

            _nbTotem = value;

        }

    }
    /*public List<Vector3> RespawnPlaces
    {

        get
        {

            return _respawnPlaces;

        }
        set
        {

            _respawnPlaces = value;

        }

    }*/
    public Vector3 RespawnPosition
    {

        get
        {

            return _respawnPosition;

        }
        set
        {

            _respawnPosition = value;

        }

    }
    public bool CanRespawn
    {

        get
        {

            return _canRespawn;

        }
        set
        {

            _canRespawn = value;

        }

    }
    public bool HasMap
    {

        get
        {

            return _hasMap;

        }
        set
        {

            _hasMap = value;

        }

    }
    public bool HasBreakableFloor
    {

        get
        {

            return _hasBreakableFloor;

        }
        set
        {

            _hasBreakableFloor = value;

        }

    }
    public bool HasMovingPlatform
    {

        get
        {

            return _hasMovingPlatform;

        }
        set
        {

            _hasMovingPlatform = value;

        }

    }
    public bool HasActivablePlatform
    {

        get
        {

            return _hasActivablePlatform;

        }
        set
        {

            _hasActivablePlatform = value;

        }

    }
    public bool HasIgnorePlatform
    {

        get
        {

            return _hasIgnorePlatform;

        }
        set
        {

            _hasIgnorePlatform = value;

        }

    }
    public bool HasDash
    {

        get
        {

            return _hasDash;

        }
        set
        {

            _hasDash = value;

        }

    }
    public bool HasWallJump
    {

        get
        {

            return _hasWallJump;

        }
        set
        {

            _hasWallJump = value;

        }

    }
    public bool HasGrapling
    {

        get
        {

            return _hasGrapling;

        }
        set
        {

            _hasGrapling = value;

        }

    }
    public bool HasAttack
    {

        get
        {

            return _hasAttack;

        }
        set
        {

            _hasAttack = value;

        }

    }

    public int HasKey
    {

        get
        {

            return _hasKey;
        
        }
        set
        {

            _hasKey = value;

        }

    }

    public bool HasFlower
    {

        get
        {

            return _hasFlower;

        }
        set
        {

            _hasFlower = value;

        }

    }

    public int Flowers
    {

        get
        {

            return _flowers;

        }
        set
        {

            _flowers = value;

        }

    }

    public int Maps
    {

        get
        {

            return _maps;

        }
        set
        {

            _maps = value;

        }

    }

    private void Awake()
    {

        _respawnPosition = _playerStart.position;

#if !UNITY_EDITOR
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
#endif

    }

}
