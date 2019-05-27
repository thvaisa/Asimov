using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

