using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    public delegate void Pressed(int i);
    public Pressed myPressed;

    public Text image;
    public string code;
    public int indx;

    public void SetDisplay(OrderButton buttonData, int indx)
    {
        image.text = buttonData.text;
        code = buttonData.code;
        this.indx = indx;
        transform.GetComponent<Button>().onClick.AddListener(Press);
    }

    public void Swap(ButtonScript buttonData)
    {
        string ttext = image.text;
        int tindx = indx;
        string tcode = code;
        image.text = buttonData.image.text;
        indx = buttonData.indx;
        code = buttonData.code;
        buttonData.image.text = ttext;
        buttonData.indx = tindx;
        buttonData.code = tcode;
    }

    public void Press()
    {
        myPressed(indx);
    }
    
}
