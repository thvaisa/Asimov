using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class LaserColor
{
    public Color color;
    public string name;
}


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




public class Laser : MonoBehaviour
{
    public LaserColorScriptable laserColors;
    private Panel panel;
    public SelectionPanel colorSelection;
    public Button shoot;
    public bool toggle = false;

    void Start()
    {
        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        colorSelection.SetList(laserColors.GetNames());
        shoot.onClick.AddListener(ToggleShoot);
    }

    public void ToggleShoot()
    {
        toggle = !toggle;
        if (toggle)
        {
            //Shooting stuff
        }
    }

    void UpdateDisplay()
    {

    }

    void UpdateMe()
    {
        
    }



}
