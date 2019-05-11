using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Queen : BaseCreature
{
    public GameObject EggPrefab;
    float layEggTimer = 0f;
    int eggTime = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetEggLayingTime();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckToLayEgg();
    }

    protected override void MoveAround()
    {
        if (changeDirectionCounter <= 0)
        {
            Vector3 randomPosition = RandomPositionAroundStart();

            moveDestination = randomPosition;
            changeDirectionCounter = 150;
        }
        else
        {
            changeDirectionCounter--;
        }

        transform.position = Vector2.MoveTowards(transform.position, moveDestination, 0.2f);
    }

    Vector3 RandomPositionAroundStart()
    {

        Vector3 randomDirection = Random.insideUnitCircle * hive.roamRadius;
        randomDirection += startPosition;

        return randomDirection;
    }

    void CheckToLayEgg()
    {
       if (layEggTimer > eggTime)
       {
            LayEgg();
            layEggTimer = 0;
            SetEggLayingTime();
       } else
       {
            layEggTimer += Time.deltaTime;
       }
    }

    void SetEggLayingTime ()
    {
        eggTime = Random.Range(hive.eggLayingTimeMin, hive.eggLayingTimeMax);
    }

    void LayEgg ()
    {
        Vector3 rPosition = Random.insideUnitCircle * hive.eggLayRadius;
        rPosition += startPosition;
        GameObject newEgg = Instantiate(EggPrefab);
        newEgg.transform.position = rPosition;
        newEgg.transform.SetParent(hive.transform);
    }
}
