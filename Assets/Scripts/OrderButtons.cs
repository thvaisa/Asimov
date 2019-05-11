using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;






public class OrderButtons : MonoBehaviour {
    public OrderButtonsScriptable orderButtons;
    public GameObject buttonPrefab;
    public List<ButtonScript> buttons;
    public Transform leftPanel;
    public Transform rightPanel;
    
    private Panel panel;

    public string sequence;
    public int lastPressed = -1;
    int checkPressed = -1;

    void Start()
    {
        
        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
        int indx = 0;
        buttons = new List<ButtonScript>();
        foreach(OrderButton orderButton in orderButtons.orderButtons)
        {
            GameObject obj = Instantiate(buttonPrefab);
            if((++indx)%2==0)
            {
                obj.transform.parent = leftPanel;
            }
            else
            {
                obj.transform.parent = rightPanel;
            }
            buttons.Add(obj.GetComponent<ButtonScript>());
            buttons[buttons.Count - 1].SetDisplay(orderButton,indx);
            buttons[buttons.Count - 1].myPressed = Pressed;
        }
        CreateSequence();
        Shuffle();
        this.panel = panel.panel;
    }


    void FailMe()
    {
        panel.Fail();
        lastPressed = -1;
    }

    void UpdateMe()
    { 
        if (lastPressed != -1)
        {
            if (panel.status == STATUS.WAITING)
            {
                FailMe();
                return;
            }

            if ((int)sequence[++checkPressed] != lastPressed)
            {
                FailMe();
                return;
            }
            if (checkPressed == buttons.Count - 1)
            {
                panel.SUCCEED();
            }
            lastPressed = -1;
        }
    }


    void Pressed(int i)
    {
        lastPressed = i;
    }


	//Use this for initialization
	void CreateSequence(){
        StringBuilder builder = new StringBuilder();
        for (int i=0; i < buttons.Count; ++i)
        {
            builder.Append(Random.Range(0,buttons.Count-1));
        }
        sequence = builder.ToString();
    }
	

    void Shuffle(){
        for(int i=buttons.Count - 1; i > 0; --i)
        {
            int j = Random.Range(0,i);
            buttons[i].Swap(buttons[j]);
        }
    }



}
