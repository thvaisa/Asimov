using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "OrderButtonsScriptable", order = 1)]
public class OrderButtonsScriptable : ScriptableObject {
    public List<OrderButton> orderButtons;
}
