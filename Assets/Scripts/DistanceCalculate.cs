using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceCalculate : MonoBehaviour
{
    public static List<Hatch> hatches { get; private set; } = new List<Hatch>();
    public float raduis = 10;
    private float distance;
    public Text distText;

    private void ControlDraw()
    {
        foreach (Hatch hatch in JSONReader.hatches)
        {
            distance = MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location);

            distText = FindObjectOfType<Text>();

            
            if (raduis >= distance && hatch.state == State.unDrawed)
            {
                hatch.distance = distance;
                hatches.Add(hatch);
            }
            distText.text = hatches.Count.ToString();
        }
    }
    
        
    

    private void ControlDelete()
    {
        foreach (Hatch hatch in hatches)
        {
            if (raduis <= MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location))
            {
                hatch.state = State.toErase;
            }

            if (hatch.state == State.toDelete)
            {
                hatch.state = State.unDrawed;
                hatches.Remove(hatch);
            }
        }
    }

    public void ControlDistance()
    {
        ControlDraw();
        ControlDelete();
    }
}
