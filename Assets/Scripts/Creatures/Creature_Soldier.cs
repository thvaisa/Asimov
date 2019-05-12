using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Soldier : BaseCreature
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void HitByLaser(GameObject explosion)
    {
        base.HitByLaser(explosion);

        TimerScript.Instance.WriteToLines("Soldier-type alien removed.");
    }
}
