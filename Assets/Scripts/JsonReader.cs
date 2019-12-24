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
    public Text lats;
 
    //public void init()
    //{
    //string abc = @"C:\abc\file.json";
    //var serializerSettings = new JsonSerializerSettings();
    //serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    //var json = JsonConvert.SerializeObject(hatch, serializerSettings)+Environment.NewLine;
    //File.AppendAllText(abc, json);
    //}
    public void init()
    {
        string path = Application.persistentDataPath + "/hatches.json";
        //string path = @"C:\abc\hatches.json";
        //Debug.Log("{ \"location\":{ \"latitude\":56.468717,\"longitude\":84.945898},\"description\":\"abcbcb\"}");
        string[] jsonString = File.ReadAllLines(path);
        
        foreach (string s in jsonString)
        {
        //string json = @"{'location':{'latitude':56.468717,'longitude':84.945898},'description':'abcbcb'}";
        //hatches.Add(JsonConvert.DeserializeObject<Hatch>(json));
         hatches.Add(JsonConvert.DeserializeObject<Hatch>(s));
            longs.text = hatches[0].location.longitude.ToString();
            lats.text = hatches[0].location.latitude.ToString();
            //Debug.Log(hatches[0].location.latitude.ToString());
            //Debug.Log(JsonConvert.DeserializeObject<Hatch>(s).location.latitude);
            //Debug.Log(JsonConvert.DeserializeObject<Hatch>(s).location.longitude);

            //Debug.Log(convertTest.location.longitude);    
        }
    }
    private void Awake()
    {
        init();
    }

}

