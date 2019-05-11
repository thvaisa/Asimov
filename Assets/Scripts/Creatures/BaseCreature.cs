using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreature : MonoBehaviour
{
    HiveBehaviour hive;

    Vector2 startPosition;
    Vector2 moveDestination;

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
        Vector2 randomDirection = Random.insideUnitCircle * hive.roamRadius;
        moveDestination = randomDirection + startPosition;

        transform.position= Vector2.MoveTowards(transform.position, moveDestination, 1f);
    }

    protected virtual void HitByLaser ()
    {

    }

    protected virtual void Die ()
    {
        hive.RemoveCreatureFromHive(this);
    }


}
