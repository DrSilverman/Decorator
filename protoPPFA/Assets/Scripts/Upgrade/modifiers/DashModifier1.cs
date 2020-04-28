using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Wall jump")]
public class WallJumpModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasWallJump = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasWallJump = false;

    }

}
