using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLine : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear ()
    {
        text.text = "";
    }

    public void Write (string message)
    {
        text.text = "> " + message;
    }

    public void AwaitingInput ()
    {
        text.text = ">";
    }

    public bool isEmpty ()
    {
        return (text.text == "");
    }

    public bool isAwaitingInput ()
    {
        return (text.text == ">");
    }
}
