using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class HiveBehaviour : MonoBehaviour
{
    public List<BaseCreature> creatures;
    public BoxCollider2D colliderBounds;

    private Panel panel;

    public float roamRadius = 30f;
    public float eggLayRadius = 80f;
    public int eggLayingTimeMin = 230; //in seconds
    public int eggLayingTimeMax = 360; //in seconds
    public float eggHatchTime = 40; //in seconds

    float ratioSoldiers = 0.5f;
    float ratioWorkers = 0.5f;
    int totalPopulation = 4;
    int queenCount = 1;
    private Creature_Queen queenObj;



    [Range(0, 100)] public float aggressiveness = 0f;
    public float maxAggressiveness = 100.0f;

    public int MAXPOP = 8;

    public GameObject glassCrack_1;
    public GameObject glassCrack_2;
    public GameObject videoArrivalPrefab;

    private void LimitAggressiviness()
    {
        aggressiveness = Mathf.Min(maxAggressiveness, aggressiveness);
        aggressiveness = Mathf.Max(0, aggressiveness);
    }

    public void IncreaseAggressiveness()
    {
        aggressiveness += 3 * totalPopulation;
        LimitAggressiviness();
    }

    public void DecreaseAggressiveness()
    {
        aggressiveness -= totalPopulation;
        LimitAggressiviness();
    }

    void Start()
    {
        colliderBounds = GetComponent<BoxCollider2D>();

        glassCrack_1.SetActive(false);
        glassCrack_2.SetActive(false);

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
        this.panel = panel.panel;

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

    void UpdateMe ()
    {

    }

    void CheckPopulationCounts()
    {
        if (queenCount < 1)
        {
            //No more queen, do lose event.
            GameLost("Queen dead");
        }
        //Hardcoded!  > 8 (>60% workers)

        if (FindObjectsOfType<CreatureQueenEgg>().Length == 0)
        {
            if (totalPopulation > MAXPOP)
            {
                queenObj.LayQueenEgg();
            }
            if (ratioWorkers > 0.6f)
            {
                queenObj.LayQueenEgg();
            }
        }


        if (totalPopulation < 4)
        {
            //Population low, insects are scared and fight.
        }
    }

    public void AddCreatureToHive(BaseCreature newCreature)
    {
        creatures.Add(newCreature);

        if (newCreature.GetComponent<Creature_Queen>())
        {
            queenObj = newCreature.GetComponent<Creature_Queen>();
        }
    }

    public void RemoveCreatureFromHive(BaseCreature removeCreature)
    {
        creatures.Remove(removeCreature);
    }

    public int GetPopulationSize()
    {
        return totalPopulation;
    }


    public void GameLost(string lossType)
    {
        if (lossType == "Aliens dead")
        {

        } else if (lossType == "Queen dead")
        {

        }

        glassCrack_2.SetActive(true);
        panel.Fail();
    }


    public float GetPopulationPercentage(){
        return GetPopulationSize() / (1.0f * MAXPOP);
    }

    public float GetAgrressivinesPercentage()
    {
        return aggressiveness / maxAggressiveness;
    }

    public void PlaySuccesEndVideo ()
    {
        GameObject endVideo = Instantiate(videoArrivalPrefab);
        endVideo.transform.SetParent(transform.parent);
        RectTransform rt = endVideo.GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(0, rt.offsetMin.y);
        rt.offsetMax = new Vector2(0, rt.offsetMax.y);
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
        rt.offsetMin = new Vector2(rt.offsetMin.x, 0);
    }
}
