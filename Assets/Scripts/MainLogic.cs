using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainLogic : MonoBehaviour {
    public List<PanelController> panels;
	
    void Start(){
        //Get all panels
        foreach(PanelController panel in FindObjectsOfType<PanelController>())
        {
            panels.Add(panel);
        }
    }

    //Check conditions
    void Check_Condition(STATUS status){
        switch (status)
        {
            case STATUS.FAIL:
                Debug.Log("FAIL");
                break;
                
            case STATUS.SUCCEED:
                Debug.Log("SUCCEED");
                break;
            default:
                break;
        };
    }

    //Go Through all the panels
    void Check(){
        foreach(PanelController panelC in panels){
            panelC.UpdateMe(); 
            STATUS status = panelC.panel.Check_status();
            Check_Condition(status);
        }
    }

    void Update()
    {
        Check();
    }

}
