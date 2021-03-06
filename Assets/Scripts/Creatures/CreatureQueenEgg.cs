﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureQueenEgg : CreatureEgg
{
    protected override void Start()
    {
        base.Start();
        hatchTimeLimit = hive.eggHatchTime;
        SoundManager.Instance.Play(eggPlaced);
        SoundManager.Instance.BioHazard();

        TimerScript.Instance.WriteToLines("Warning! Swarming event imminent.");
    }

    // Update is called once per frame
    protected override void Update()
    {
        //base.Update(); //no moving around for eggs
        CheckForHatching();
    }

    void CheckForHatching ()
    {
        if (hatchTimer > hatchTimeLimit)
        {
            Hatch();
        } else
        {
            hatchTimer += Time.deltaTime;
        }
    }

    void Hatch ()
    {
        float random = Random.Range(0, 100f);

        GameObject newCreature;

        newCreature = Instantiate(queenPrefab);
        newCreature.transform.position = transform.position;
        newCreature.transform.SetParent(hive.transform);

        //Play sound here?
        SoundManager.Instance.Play(eggCrack);
        hive.RemoveCreatureFromHive(this);
        Destroy(this.gameObject);
    }

    public override void HitByLaser(GameObject explosion)
    {
        base.HitByLaser(explosion);

        TimerScript.Instance.WriteToLines("Anomaly removed.");
        SoundManager.Instance.SwarmRemoved();
    }
}
