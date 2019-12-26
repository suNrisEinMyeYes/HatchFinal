using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class JSONReader : MonoBehaviour
{
    public static List<Hatch> hatches = new List<Hatch>();
    public Text longs;
    //public Text lats;
 
   
    public void init()
    {
        string path = Application.persistentDataPath + "/hatches.json";
        //string path = @"C:\abc\hatches.json";
        string[] jsonString = File.ReadAllLines(path);
        
        foreach (string s in jsonString)
        {
            hatches.Add(JsonConvert.DeserializeObject<Hatch>(s));
        }
       longs.text = hatches.Count.ToString();
    }
    private void Start()
    {
        init();
    }

}

