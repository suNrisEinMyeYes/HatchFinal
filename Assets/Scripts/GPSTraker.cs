using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSTraker : MonoBehaviour
{
    private static GPSLocation _currentLocation;
    public static GPSLocation currentlocation { get => _currentLocation; }
    //private static List<GPSLocation> locations = new List<GPSLocation>{ };
    public Text longit;
    public Text lat;
    public Text alt;



    public static float angleToNorth
    {
        get => Input.location.status == LocationServiceStatus.Running ? -Input.compass.trueHeading : 0;
    }

    public void StartTraking()
    {
        if (Input.location.isEnabledByUser)
        {
            Input.location.Start(1f,0.1f);
        }
    }

    private void UpdateLocation()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            _currentLocation.latitude = Input.location.lastData.latitude;
            _currentLocation.longitude = Input.location.lastData.longitude;
            longit.text = _currentLocation.longitude.ToString();
            lat.text = _currentLocation.latitude.ToString();
            alt.text = Input.location.lastData.altitude.ToString();
        }
    }

    private void Awake()
    {
        StartTraking();
    }

    private void Update()
    {
        UpdateLocation();
    }
    
}
