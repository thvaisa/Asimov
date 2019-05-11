using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreature : MonoBehaviour
{
    HiveBehaviour hive;

    Vector3 startPosition;
    Vector3 moveDestination;
    int changeDirectionCounter = 0;

    protected virtual void Start()
    {
        hive = GameObject.FindObjectOfType<HiveBehaviour>();
        hive.AddCreatureToHive(this);

        startPosition = GetStartingPosition();
    }


    protected virtual void Update()
    {
        MoveAround();
    }

    protected virtual Vector3 GetStartingPosition ()
    {
        return transform.position;
    }

    protected virtual void MoveAround ()
    {
        if (changeDirectionCounter <= 0) {
            Vector3 randomPosition = GetRandomPosition();

            moveDestination = randomPosition;
            changeDirectionCounter = 200;
        } else
        {
            changeDirectionCounter--;
        }

        transform.position = Vector2.MoveTowards(transform.position, moveDestination, 0.2f);
    }

    Vector3 GetRandomPosition ()
    {
        Vector3 randomDirection = Random.insideUnitCircle * hive.roamRadius;
        randomDirection += startPosition;

        if (hive.colliderBounds.bounds.Contains(moveDestination))
        {
            return randomDirection;
        }
        else
        {
            return startPosition;
        }
    }

    protected virtual void HitByLaser ()
    {

    }

    protected virtual void Die ()
    {
        hive.RemoveCreatureFromHive(this);
    }


}
