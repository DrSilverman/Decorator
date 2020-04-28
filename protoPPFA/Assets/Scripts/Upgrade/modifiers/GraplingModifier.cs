using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Grapling")]
public class GraplingModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {

        hook script = Script.gameObject.AddComponent<hook>();

        script.ShadowCanvas = GameManager.Instance.ShadowCanvas;
        script.Shadow = GameManager.Instance.Shadow;
        script.FauxShadow = GameManager.Instance.FauxShadow;
        script.All= GameManager.Instance.All;
        script.Text= GameManager.Instance.Text;

        script.Cutscene();

    }

    public override void Remove(MonoBehaviour Script)
    {

        Destroy(Script.gameObject.GetComponent<hook>());

    }

}
