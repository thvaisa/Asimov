using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Queen : BaseCreature
{
    public GameObject EggPrefab;
    int layEggTimer = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
       if (layEggTimer > 100f)
       {
            LayEgg();
            layEggTimer = 0;
       } else
       {
            layEggTimer++;
       }
    }

    void LayEgg ()
    {
        Vector3 rPosition = Random.insideUnitCircle * hive.roamRadius;
        rPosition += startPosition;
        GameObject newEgg = Instantiate(EggPrefab);
        newEgg.transform.position = rPosition;
        newEgg.transform.SetParent(hive.transform);
    }
}
