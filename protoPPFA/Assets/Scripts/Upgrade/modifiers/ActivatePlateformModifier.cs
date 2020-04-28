using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Activate plateform")]
public class ActivatePlateformModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasActivablePlatform = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasActivablePlatform = false;

    }

}
