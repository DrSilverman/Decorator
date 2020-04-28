using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Dash")]
public class DashModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasDash = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasDash = false;

    }

}
