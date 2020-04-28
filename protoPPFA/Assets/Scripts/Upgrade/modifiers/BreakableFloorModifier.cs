using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Breakable floor")]
public class BreakableFloorModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasBreakableFloor = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasBreakableFloor = false;

    }

}
