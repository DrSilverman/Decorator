﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Moving plateform")]
public class MovingPlateformModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasMovingPlatform = true;

    }

    public override void Remove(MonoBehaviour Script)
    {

        PlayerManager.Instance.HasMovingPlatform = false;

    }

}
