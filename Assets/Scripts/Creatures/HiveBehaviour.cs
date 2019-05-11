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
    //public NavMesh _nav;

    void Start()
    {
        colliderBounds = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

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
