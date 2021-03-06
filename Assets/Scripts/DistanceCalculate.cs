﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceCalculate : MonoBehaviour
{
    public static List<Hatch> hatches { get; private set; } = new List<Hatch>();
    public float raduis = 10f;
    private float distance;
    private int[] unique = new int[JSONReader.hatches.Count];
    //public Text distText;
    

    private void ControlDraw()
    {

        
        foreach (Hatch hatch in JSONReader.hatches)
        {
            
            distance = MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location);
           
            //distText = FindObjectOfType<Text>();
            //asd = FindObjectOfType<Text>();
            
            //distText.text = "asd";
            if (raduis >= distance && hatch.state == State.unDrawed)
            {
                hatch.distance = distance;
                hatches.Add(hatch);
                
            }
            
            
        }
    }




    private void ControlErase()
    {
        foreach (Hatch hatch in hatches)
        {
            if (raduis <= MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location))
            {
                hatch.state = State.toErase;
            }
        }
        
    }


    private void ControlDelete()
    {
       
        for (int i = 0; i < hatches.Count; i++)
        {
            if (hatches[i].state == State.toDelete)
            {
                hatches[i].state = State.unDrawed;
                

                hatches.RemoveAt(i);

                i--;
            }
        }
    }

    public void ControlDistance()
    {
        ControlDraw();
        ControlDelete();
        ControlErase();
    }
}
