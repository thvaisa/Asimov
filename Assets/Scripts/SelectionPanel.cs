using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionPanel : MonoBehaviour
{
    public Text text;
    public Button plusButton;
    public Button minusButton;

    public int indx = 0;
    
    List<string> names;
    
    public void Start()
    {
        names = new List<string>();
    }


    // Start is called before the first frame update
    public void SetList(List<string> nameList)
    {
        foreach (var name in nameList)
        {
            names.Add(name);
        }
        plusButton.onClick.AddListener(Plus);
        minusButton.onClick.AddListener(Minus);
        text.text = names[indx];
    }


    void Plus()
    {
      
        ++indx;
        CheckLimits();
        UpdateText();
    }

    void UpdateText()
    {
        text.text = names[indx];
    }

    void CheckLimits()
    {
        if (indx > names.Count - 1)
        {
            indx = 0;
        }
        else if (indx < 0)
        {
            indx = names.Count - 1;
        }
    }

    void Minus()
    {
        --indx;
        CheckLimits();
        UpdateText();
    }
}
