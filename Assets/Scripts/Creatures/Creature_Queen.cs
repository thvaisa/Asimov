using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Queen : BaseCreature
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
}
