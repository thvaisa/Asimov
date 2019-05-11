using System.Collections;
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

    public Image shapeImage;
    public Image spiceImage;

    public AudioClip dispenseClip;


    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        colorSelection.SetList(foodColors.GetNames());
        shapeSelection.SetList(foodShapes.GetNames());
        spiceSelection.SetList(foodSpices.GetNames());
        colorSelection.UpdateSmth = UpdateDisplay;
        shapeSelection.UpdateSmth = UpdateDisplay;
        spiceSelection.UpdateSmth = UpdateDisplay;
        dispenser.onClick.AddListener(DispensePress);
        this.panel = panel.panel;
        UpdateDisplay();
    }

    public void DispensePress()
    {
        dispensePressed = true;
        SoundManager.Instance.Play(dispenseClip);
    }

    void FailMe()
    {
        panel.Fail();
    }

    void UpdateDisplay()
    {
        shapeImage.color = foodColors.foodColors[colorSelection.indx].color;
        shapeImage.sprite = foodShapes.foodShapes[shapeSelection.indx].image;
        spiceImage.sprite = foodSpices.foodSpices[spiceSelection.indx].image;
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
