using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "FoodColorScriptable", order = 1)]
public class FoodColorScriptable : ScriptableObject
{
    public List<FoodColor> foodColors;

    public List<string> GetNames()
    {
        List<string> names = new List<string>();
        foreach(FoodColor color in foodColors)
        {
            names.Add(color.name);
        }
        return names;
    }

}

