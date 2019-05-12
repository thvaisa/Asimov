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

    public HiveBehaviour hive;
    public TimerScript timer;


    public bool CorrectFood(int popSize, int Angriness, int Hungriness){
        if (popSize == 5) popSize -= 1;
        if (Angriness == 5) Angriness -= 1;
        if (Hungriness == 5) Hungriness -= 1;
        int indx0 = 3 * (popSize + 5 * Angriness + Hungriness * 5 * 5);
        int conds = 0;
        //Debug.Log(indx0);
        //Debug.Log(foodData.data.Length);
        //Debug.Log(popSize.ToString()+","+Angriness.ToString() + ","+Hungriness.ToString());
        //Debug.Log("INDEX: "+foodData.data[indx0].ToString() + "," + foodData.data[indx0 + 1].ToString() + "," + foodData.data[indx0 + 2].ToString());
        //Debug.Log("INDEX: " + foodColors.foodColors.Count.ToString() + "," + foodShapes.foodShapes.Count.ToString() + "," + foodSpices.foodSpices.Count.ToString());
        //Debug.Log(foodData.data[indx0]);
        int i = (int)System.Char.GetNumericValue(foodData.data[indx0]);
        int j = (int)System.Char.GetNumericValue(foodData.data[indx0+1]);
        int k = (int)System.Char.GetNumericValue(foodData.data[indx0+2]);
        //Debug.Log((int)(foodData.data[indx0]));
        //Debug.Log(foodColors.foodColors[(int)(foodData.data[indx0])].name);
        Debug.Log("Expected: " + foodColors.foodColors[i].name+","+ foodShapes.foodShapes[j].name + "," + foodSpices.foodSpices[k].name);
        conds += CheckCondition(colorSelection.indx, foodData.data[indx0]);
        conds += CheckCondition(shapeSelection.indx, foodData.data[indx0+1]);
        conds += CheckCondition(spiceSelection.indx, foodData.data[indx0+2]);
        return (conds == 3);
    }


    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
        //foreach(string name in foodColors.GetNames())
        //{
        //    Debug.Log(name);
        //}
        colorSelection.SetList(foodColors.GetNames());
        shapeSelection.SetList(foodShapes.GetNames());
        spiceSelection.SetList(foodSpices.GetNames());
        colorSelection.UpdateSmth = UpdateDisplay;
        shapeSelection.UpdateSmth = UpdateDisplay;
        spiceSelection.UpdateSmth = UpdateDisplay;
        dispenser.onClick.AddListener(DispensePress);
        this.panel = panel.panel;
        
        hive = FindObjectOfType<HiveBehaviour>();
        timer = FindObjectOfType<TimerScript>();
        UpdateDisplay();
    }

    public void DispensePress()
    {
        dispensePressed = true;
        SoundManager.Instance.Play(dispenseClip);
        TimerScript.Instance.WriteToLines("Food dispensed.");
    }

    void FailMe()
    {
        panel.Fail();
    }

    void UpdateDisplay()
    {
        Debug.Log(foodColors.foodColors[colorSelection.indx].name+ "," +foodShapes.foodShapes[shapeSelection.indx].name + "," + foodSpices.foodSpices[spiceSelection.indx].name);
        CorrectFood((int)(5 * hive.GetAgrressivinesPercentage()), (int)(5 * timer.GetHungriness()), (int)(5 * hive.GetPopulationPercentage()));
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
            if (CorrectFood((int)(5 * hive.GetAgrressivinesPercentage()), (int)(5 * timer.GetHungriness()), (int)(5 * hive.GetPopulationPercentage())))
            {
                hive.DecreaseAggressiveness();
                timer.Eat();
            }
            else
            {
                hive.IncreaseAggressiveness();
            }
        }
    }



}
