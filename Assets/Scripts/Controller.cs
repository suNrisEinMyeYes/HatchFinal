using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Drawer))]
public class Controller : MonoBehaviour
{
    private DistanceCalculate dc;
    private PositionTerminator pt;
    private Drawer drawer;

    private void Awake()
    {
        dc = new DistanceCalculate();
        pt = new PositionTerminator();
        drawer = GetComponent<Drawer>();
    }


    // Update is called once per frame
    void Update()
    {
        dc.ControlDistance();
        pt.CanculateDistance();
        drawer.DrawObject();
    }
}
