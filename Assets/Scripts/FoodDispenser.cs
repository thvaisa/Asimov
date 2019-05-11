﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;





public class FoodDispenser : MonoBehaviour
{
    public FoodColorScriptable foodColors;
    public FoodShapeScriptable foodShapes;
    public FoodSpiceScriptable foodSpices;

    private Panel panel;

    public SelectionPanel colorSelection;
    public SelectionPanel shapeSelection;
    public SelectionPanel spiceSelection;

    public Button dispenser;

    public bool dispensePressed = false;
    public string expectColor;
    public string expectShape;
    public string expectSpice;

    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        colorSelection.SetList(foodColors.GetNames());
        shapeSelection.SetList(foodShapes.GetNames());
        spiceSelection.SetList(foodSpices.GetNames());

        dispenser.onClick.AddListener(DispensePress);
    }

    public void DispensePress()
    {
        dispensePressed = true;
    }

    void FailMe()
    {
        panel.Fail();
    }

    void UpdateDisplay()
    {

    }


    int CheckCondition(string name, string name2)
    {
        if(name.Equals(name2)) return 1;
        return 0;
    }

    void UpdateMe()
    {
        int conds = 0;
        if (dispensePressed)
        {
            conds += CheckCondition(foodColors.foodColors[colorSelection.indx].name, expectColor) ;
            conds += CheckCondition(foodShapes.foodShapes[shapeSelection.indx].name, expectShape);
            conds += CheckCondition(foodSpices.foodSpices[spiceSelection.indx].name, expectSpice);
            if (conds == 3)
            {
                panel.SUCCEED();
            }
            else
            {
                panel.Fail();
            }
        }
    }



}