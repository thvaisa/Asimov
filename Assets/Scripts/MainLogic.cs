using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainLogic : MonoBehaviour {
    public List<Panel> panels;
	
    void Start(){
        //Get all panels
        foreach(PanelController panel in FindObjectsOfType<PanelController>())
        {
            panels.Add(panel.GetComponent<Panel>());
        }
    }

    //Check conditions
    void Check_Condition(STATUS status){
        switch (status)
        {
            case STATUS.FAIL:
                break;
                //EXPLODE
            case STATUS.SUCCEED:
                break;
                //NEXT PUZZLE
            default:
                break;
        };
    }

    //Go Through all the panels
    void Check(){
        foreach(Panel panel in panels){
            STATUS status = panel.Check_status();
            Check_Condition(status);
        }
    }

    void Update()
    {
        Check();
    }

}
