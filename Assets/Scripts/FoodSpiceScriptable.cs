using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "FoodSpiceScriptable", order = 1)]
public class FoodSpiceScriptable : ScriptableObject
{
    public List<FoodSpice> foodSpices;
    public List<string> GetNames()
    {
        List<string> names = new List<string>();
        foreach (FoodSpice spice in foodSpices)
        {
            names.Add(spice.name);
        }
        return names;
    }
}
