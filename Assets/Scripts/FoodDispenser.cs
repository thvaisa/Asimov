using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;





public class FoodDispenser : MonoBehaviour
{

    public DataArray foodData;
    public int elems; 

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

    public bool CorrectFood(int popSize, int Angriness, int Hungriness){
        int indx0 = 3 * (popSize + 5 * Angriness + Hungriness * 5 * 5);
        int conds = 0;
        conds += CheckCondition(colorSelection.indx, foodData.data[indx0]);
        conds += CheckCondition(shapeSelection.indx, foodData.data[indx0+1]);
        conds += CheckCondition(spiceSelection.indx, foodData.data[indx0+2]);
        return (conds == 3);
    }


    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
        foreach(string name in foodColors.GetNames())
        {
            Debug.Log(name);
        }
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
        Debug.Log(foodColors.foodColors[colorSelection.indx].name+ "," +foodShapes.foodShapes[shapeSelection.indx].name + "," + foodSpices.foodSpices[spiceSelection.indx].name);
        shapeImage.color = foodColors.foodColors[colorSelection.indx].color;
        shapeImage.sprite = foodShapes.foodShapes[shapeSelection.indx].image;
        spiceImage.sprite = foodSpices.foodSpices[spiceSelection.indx].image;
    }


    int CheckCondition(int name, int name2)
    {
        if(name==name2) return 1;
        return 0;
    }

    void UpdateMe()
    {
       
        if (dispensePressed)
        {

            if (CorrectFood(1,1,1))
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
