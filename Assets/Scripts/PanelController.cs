using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {
    public Panel panel = new Panel();

    public delegate void MyUpdate();
    public MyUpdate UpdateMe;
   
 
}
