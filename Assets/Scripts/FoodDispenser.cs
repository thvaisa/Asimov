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


    public bool CorrectFood( int Angriness, int popSize, int Hungriness){
        if (popSize > 4) popSize = 4;
        if (Angriness > 4) Angriness = 4;
        if (Hungriness > 4) Hungriness =4;
        int indx0 = 3 * (Angriness + 5 * popSize + Hungriness * 5 * 5);
        int conds = 0;
        //Debug.Log(indx0);
        //Debug.Log(foodData.data.Length);
        Debug.Log(Angriness.ToString()+","+ popSize.ToString() + ","+Hungriness.ToString());
      
        Debug.Log("INDEX: "+foodData.data[indx0].ToString() + "," + foodData.data[indx0 + 1].ToString() + "," + foodData.data[indx0 + 2].ToString());
        //Debug.Log("INDEX: " + foodColors.foodColors.Count.ToString() + "," + foodShapes.foodShapes.Count.ToString() + "," + foodSpices.foodSpices.Count.ToString());
        //Debug.Log(foodData.data[indx0]);
        Debug.Log(indx0);
        int i = (int)System.Char.GetNumericValue(foodData.data[indx0]);
        int j = (int)System.Char.GetNumericValue(foodData.data[indx0+1]);
        int k = (int)System.Char.GetNumericValue(foodData.data[indx0+2]);
       
        //Debug.Log((int)(foodData.data[indx0]));
        //Debug.Log(foodColors.foodColors[(int)(foodData.data[indx0])].name);
        Debug.Log("Expected: " + foodColors.foodColors[i].name+","+ foodShapes.foodShapes[j].name + "," + foodSpices.foodSpices[k].name);
        Debug.Log("Colors: " + colorSelection.indx.ToString() + "," + shapeSelection.indx.ToString() + "," + spiceSelection.indx.ToString());
        conds += CheckCondition(colorSelection.indx, i);
        conds += CheckCondition(shapeSelection.indx, j);
        conds += CheckCondition(spiceSelection.indx, k);
        Debug.Log("conds " + conds.ToString());
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
        Debug.Log("HUngry" + ((int)(5 * timer.GetHungriness())).ToString() + " " + timer.GetHungriness().ToString());
        Debug.Log("asdasd"+timer.GetHungriness().ToString());
        Debug.Log(foodColors.foodColors[colorSelection.indx].name+ "," +foodShapes.foodShapes[shapeSelection.indx].name + "," + foodSpices.foodSpices[spiceSelection.indx].name);
        CorrectFood((int)(5 * hive.GetAgrressivinesPercentage()), (int)(5 * hive.GetPopulationPercentage()), (int)(5 * timer.GetHungriness()));
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
            Debug.Log("HUngry"+((int)(5 * timer.GetHungriness())).ToString()+" "+ timer.GetHungriness().ToString());
            
            if (CorrectFood((int)(5 * hive.GetAgrressivinesPercentage()), (int)(5 * hive.GetPopulationPercentage()), (int)(5 * timer.GetHungriness())))
            {
                Debug.Log("correct food");
                hive.DecreaseAggressiveness();
                timer.Eat();
            }
            else
            {
                Debug.Log("wrong food");
                hive.IncreaseAggressiveness();
            }
            dispensePressed = false;
        }
    }



}
