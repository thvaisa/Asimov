using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class HiveBehaviour : MonoBehaviour
{
    public List<BaseCreature> creatures;
    public BoxCollider2D colliderBounds;

    public float roamRadius = 30f;
    public float eggLayRadius = 40f;
    public int eggLayingTimeMin = 230; //in seconds
    public int eggLayingTimeMax = 360; //in seconds
    public float eggHatchTime = 40; //in seconds

    float ratioSoldiers = 0.5f;
    float ratioWorkers = 0.5f;
    int totalPopulation = 4;

    void Start()
    {
        colliderBounds = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        UpdateRatios();
        CheckPopulationCounts();
    }

    void UpdateRatios()
    {
        int workerCount = 0;
        int soldierCount = 0;
        foreach (BaseCreature creature in creatures)
        {
            if (creature.GetComponent<Creature_Worker>())
            {
                workerCount++;
            } else if (creature.GetComponent<Creature_Soldier>())
            {
                soldierCount++;
            }
        }
        totalPopulation = workerCount + soldierCount;
        ratioSoldiers = soldierCount / totalPopulation;
        ratioWorkers = workerCount / totalPopulation;
    }

    void CheckPopulationCounts()
    {
        //Hardcoded!
    }

    public void AddCreatureToHive (BaseCreature newCreature)
    {
        creatures.Add(newCreature);
    }

    public void RemoveCreatureFromHive(BaseCreature removeCreature)
    {
        creatures.Remove(removeCreature);
    }
}
