using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Attack")]
public class AttackModifier : UpgradeModifiers
{

    public override void Apply(MonoBehaviour Script)
    {
        //change for the attack
        Attack script = Script.gameObject.AddComponent<Attack>();

        script.Faux = GameManager.Instance.Faux;
        script.Origin = GameManager.Instance.Origin;
        script.Target = GameManager.Instance.Target;
        script.Anim = GameManager.Instance.Anim;

        script.ShadowCanvas = GameManager.Instance.ShadowCanvas;
        script.Shadow = GameManager.Instance.Shadow;
        script.FauxShadow = GameManager.Instance.FauxShadow;
        script.All= GameManager.Instance.All;
        script.Text= GameManager.Instance.Text;

        script.Cutscene();

    }

    public override void Remove(MonoBehaviour Script)
    {
        
        //same
        Destroy(Script.gameObject.GetComponent<Attack>());

    }

}
