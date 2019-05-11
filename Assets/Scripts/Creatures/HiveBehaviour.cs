using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class HiveBehaviour : MonoBehaviour
{
    public List<BaseCreature> creatures;
    public BoxCollider2D colliderBounds;

    public float roamRadius = 30f;
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
