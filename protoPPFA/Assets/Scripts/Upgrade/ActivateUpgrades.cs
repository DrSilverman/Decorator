using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUpgrades : MonoBehaviour
{

    [SerializeField] private UpgradeModifiers _faux = null;
    [SerializeField] private UpgradeModifiers _grapin = null;
    [SerializeField] private UpgradeModifiers _dash = null;
    [SerializeField] private UpgradeModifiers _movingPlatform = null;
    [SerializeField] private UpgradeModifiers _wallJump = null;
    [SerializeField] private UpgradeModifiers _activablePlatform = null;
    [SerializeField] private UpgradeModifiers _ignorePlatform = null;
    [SerializeField] private UpgradeModifiers _breakableFloor = null;

    private bool _fauxRemoved = false;
    private bool _graplingRemoved = false;
    private bool _dashRemoved = false;
    private bool _movingPlatformRemoved = false;
    private bool _wallJumpRemoved = false;
    private bool _activablePlatformRemoved = false;
    private bool _ignorePlatformRemoved = false;
    private bool _breakableFloorRemoved = false;

    private void OnDisable()
    {

        _faux.Remove(this);
        _fauxRemoved = true;

        _grapin.Remove(this);
        _graplingRemoved = true;

        _dash.Remove(this);
        _dashRemoved = true;

        _movingPlatform.Remove(this);
        _movingPlatformRemoved = true;

        _wallJump.Remove(this);
        _wallJumpRemoved = true;

        _activablePlatform.Remove(this);
        _activablePlatformRemoved = true;

        _ignorePlatform.Remove(this);
        _ignorePlatformRemoved = true;

        _breakableFloor.Remove(this);
        _breakableFloorRemoved = true;

    }

    private void Update()
    {

        if (!PlayerManager.Instance.HasAttack && !_fauxRemoved)
        {

            _faux.Remove(this);

            _fauxRemoved = true;

        }
        else if (PlayerManager.Instance.HasAttack && _fauxRemoved)
        {

            _faux.Apply(this);

            _fauxRemoved = false;

        }

        if (!PlayerManager.Instance.HasGrapling && !_graplingRemoved)
        {

            _grapin.Remove(this);

            _graplingRemoved = true;

        }else if (PlayerManager.Instance.HasGrapling && _graplingRemoved)
        {

            _grapin.Apply(this);

            _graplingRemoved = false;

        }

        /*if (!PlayerManager.Instance.HasDash && !_dashRemoved)
        {

            _dash.Remove(this);

            _dashRemoved = true;

        }
        else if (PlayerManager.Instance.HasDash && _dashRemoved)
        {

            _dash.Apply(this);

            _dashRemoved = false;

        }

        if (!PlayerManager.Instance.HasMovingPlatform && !_movingPlatformRemoved)
        {

            _movingPlatform.Remove(this);

            _movingPlatformRemoved = true;

        }
        else if (PlayerManager.Instance.HasMovingPlatform && _movingPlatformRemoved)
        {

            _movingPlatform.Apply(this);

            _movingPlatformRemoved = false;

        }

        if (!PlayerManager.Instance.HasWallJump && !_wallJumpRemoved)
        {

            _wallJump.Remove(this);

            _wallJumpRemoved = true;

        }
        else if (PlayerManager.Instance.HasWallJump && _wallJumpRemoved)
        {

            _wallJump.Apply(this);

            _wallJumpRemoved = false;

        }

        if (!PlayerManager.Instance.HasActivablePlatform && !_activablePlatformRemoved)
        {

            _activablePlatform.Remove(this);

            _activablePlatformRemoved = true;

        }
        else if (PlayerManager.Instance.HasActivablePlatform && _activablePlatformRemoved)
        {

            _activablePlatform.Apply(this);

            _activablePlatformRemoved = false;

        }

        if (!PlayerManager.Instance.HasIgnorePlatform && !_ignorePlatformRemoved)
        {

            _ignorePlatform.Remove(this);

            _ignorePlatformRemoved = true;

        }
        else if (PlayerManager.Instance.HasIgnorePlatform && _ignorePlatformRemoved)
        {

            _ignorePlatform.Apply(this);

            _ignorePlatformRemoved = false;

        }

        if (!PlayerManager.Instance.HasBreakableFloor && !_breakableFloorRemoved)
        {

            _breakableFloor.Remove(this);

            _breakableFloorRemoved = true;

        }
        else if (PlayerManager.Instance.HasBreakableFloor && _breakableFloorRemoved)
        {

            _breakableFloor.Apply(this);

            _breakableFloorRemoved = false;

        }*/

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<BrokenFaux>())
        {

            _faux.Apply(this);

            PlayerManager.Instance.HasAttack = true;

            _fauxRemoved = false;

            Destroy(other.gameObject);

        }

        if (other.GetComponent<Grapin>())
        {

            _grapin.Apply(this);

            PlayerManager.Instance.HasGrapling = true;

            _graplingRemoved = false;

            Destroy(other.gameObject);

        }

    }

}
