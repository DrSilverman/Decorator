using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Ignore plateform")]
public class IgnorePlateformModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasIgnorePlatform = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasIgnorePlatform = false;

    }

}
