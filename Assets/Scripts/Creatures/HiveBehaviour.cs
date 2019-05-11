using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class HiveBehaviour : MonoBehaviour
{
    public List<BaseCreature> creatures;
    public BoxCollider2D colliderBounds;

    public float roamRadius = 30f;
    public float eggLayRadius = 80f;
    public int eggLayingTimeMin = 230; //in seconds
    public int eggLayingTimeMax = 360; //in seconds
    public float eggHatchTime = 40; //in seconds

    float ratioSoldiers = 0.5f;
    float ratioWorkers = 0.5f;
    int totalPopulation = 4;
    int queenCount = 1;


    public GameObject glassCrack_1;
    public GameObject glassCrack_2;

    void Start()
    {
        colliderBounds = GetComponent<BoxCollider2D>();

        glassCrack_1.SetActive(false);
        glassCrack_2.SetActive(false);
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
            } else if (creature.GetComponent<Creature_Queen>())
            {
                queenCount++;
            }
        }
        totalPopulation = workerCount + soldierCount;
        if (totalPopulation > 0)
        {
            ratioSoldiers = soldierCount / totalPopulation;
            ratioWorkers = workerCount / totalPopulation;
        } else
        {
            //Nothing left. 
            GameLost("Aliens dead");
        }

    }

    void CheckPopulationCounts()
    {
        if (queenCount < 1)
        {
            //No more queen, do lose event.
            GameLost("Queen dead");
        }
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

    public void GameLost(string lossType)
    {
        if (lossType == "Aliens dead")
        {

        } else if (lossType == "Queen dead")
        {

        }

        glassCrack_2.SetActive(true);
    }
}
