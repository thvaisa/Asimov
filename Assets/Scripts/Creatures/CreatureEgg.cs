using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEgg : BaseCreature
{
    public GameObject soldierPrefab;
    public GameObject workerPrefab;
    public GameObject queenPrefab;

    float hatchTimer = 0f;
    float hatchTimeLimit = 30f; //in seconds

    public AudioClip warningtest;
    public AudioClip eggPlaced;
    public AudioClip eggCrack;

    protected override void Start()
    {
        base.Start();
        hatchTimeLimit = hive.eggHatchTime;
        SoundManager.Instance.Play(eggPlaced);

        TimerScript.Instance.WriteToLines("New egg detected.");
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
        if (random < 50)
        {
            newCreature = Instantiate(soldierPrefab);
        } else
        {
            newCreature = Instantiate(workerPrefab);
        }
        newCreature.transform.position = transform.position;
        newCreature.transform.SetParent(hive.transform);

        //Play sound here?
        TimerScript.Instance.WriteToLines("Egg hatched.");
        SoundManager.Instance.Play(eggCrack);
        hive.RemoveCreatureFromHive(this);
        Destroy(this.gameObject);
    }

    public override void HitByLaser(GameObject explosion)
    {
        base.HitByLaser(explosion);

        TimerScript.Instance.WriteToLines("Egg removed.");
        SoundManager.Instance.Play(eggCrack);

        //Should anger the aliens???
    }
}
