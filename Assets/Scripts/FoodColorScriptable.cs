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

[CreateAssetMenu(fileName = "Data", menuName = "FoodShapeScriptable", order = 1)]
public class FoodShapeScriptable : ScriptableObject
{
    public List<FoodShape> foodShapes;

    public List<string> GetNames()
    {
        List<string> names = new List<string>();
        foreach (FoodShape shape in foodShapes)
        {
            names.Add(shape.name);
        }
        return names;
    }
}

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
