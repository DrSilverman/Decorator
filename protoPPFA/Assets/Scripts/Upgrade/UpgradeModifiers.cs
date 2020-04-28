using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeModifiers : ScriptableObject
{

    public abstract void Apply(MonoBehaviour Script);
    public abstract void Remove(MonoBehaviour Script);

}
