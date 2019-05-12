using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainLogic : MonoBehaviour {
    public List<PanelController> panels;
    public bool gameOver = false;

    public AudioClip voiceWin;
    public AudioClip voiceLoss;
	
    void Start(){
        //Get all panels
        foreach(PanelController panel in FindObjectsOfType<PanelController>())
        {
            panels.Add(panel);
        }
    }

    //Check conditions
    void Check_Condition(STATUS status){
        if (!gameOver) { 
            switch (status)
            {
                case STATUS.FAIL:
                    Debug.Log("FAIL");
                    SoundManager.Instance.Play(voiceLoss);
                    SoundManager.Instance.FadeMusic();
                    gameOver = true;
                    break;
                
                case STATUS.SUCCEED:
                    Debug.Log("SUCCEED");
                    FindObjectOfType<HiveBehaviour>().PlaySuccesEndVideo();
                    SoundManager.Instance.Play(voiceWin);
                    SoundManager.Instance.FadeMusic();
                    gameOver = true;
                    //INSERT SOUND FOR SUCCES TODO
                    break;
                default:
                    break;
            };
        }
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
