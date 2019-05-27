using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "LaserColorScriptable", order = 1)]
public class LaserColorScriptable : ScriptableObject
{
    public List<LaserColor> laserColors;

    public List<string> GetNames()
    {
        List<string> names = new List<string>();
        foreach (LaserColor color in laserColors)
        {
            names.Add(color.name);
        }
        return names;
    }

}