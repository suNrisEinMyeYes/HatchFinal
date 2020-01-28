using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

public class testJS : MonoBehaviour
{
    public void init()
    {
        Proxy hatch = new Proxy
        {
            
            description = "fuck",
            location = new GPSLocation
            {
                latitude = 124f,
                longitude = 12f
            },
            state = State.unDrawed
            
            
        };

        string abc = @"C:\abc\file.json";

        var json = JsonUtility.ToJson(hatch);
        File.WriteAllText(abc, json);
    }
    public void des()
    {


        string abc = @"C:\abc\file.json";
        string jsonString = File.ReadAllText(abc);

        Hatch jobject = JsonConvert.DeserializeObject<Hatch>(jsonString);
        Debug.Log(jobject.description);
    }
    private void Awake()
    {
        init();
        des();
    }
}
