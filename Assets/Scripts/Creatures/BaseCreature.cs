using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreature : MonoBehaviour
{
    protected HiveBehaviour hive;

    protected Vector3 startPosition;
    protected Vector3 moveDestination;
    protected int changeDirectionCounter = 0;

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
            Vector3 randomPosition = RandomPointInBounds();

            moveDestination = randomPosition;
            changeDirectionCounter = 150;
        } else
        {
            changeDirectionCounter--;
        }

        transform.position = Vector2.MoveTowards(transform.position, moveDestination, 0.2f);
    }


    Vector3 RandomPointInBounds() {
        Bounds bounds = hive.colliderBounds.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public virtual void HitByLaser (GameObject laserExplosion)
    {
        Die();

        GameObject explosion = Instantiate(laserExplosion);
        explosion.transform.SetParent(transform);
        explosion.transform.position = transform.position;

        Destroy(gameObject);
    }

    protected virtual void Die ()
    {
        hive.RemoveCreatureFromHive(this);
    }


}
