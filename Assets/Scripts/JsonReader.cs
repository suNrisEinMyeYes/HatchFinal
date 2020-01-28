
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using UnityEngine;
using UnityEngine.UI;


//using System.Text.Json;
//using System.Text.Json.Serialization;


public class JSONReader : MonoBehaviour
{
    public static List<Hatch> hatches = new List<Hatch>();
    
    public Text lats;
    public static int Size;
    public string[] Output;

    

    public void init()
    {
        string path = Application.persistentDataPath + "/hatches.json";
        //string path = @"C:\abc\hatches.json";
        string[] jsonString = File.ReadAllLines(path);

        foreach (string s in jsonString)
        {
            hatches.Add(JsonConvert.DeserializeObject<Hatch>(s));
        }
        Size = hatches.Count;
        lats.text = Size.ToString();
        //Debug.Log("Size: " + Size);
    }
    private void Start()
    {
        init();
        
        //Debug.Log("done");
    }

    private void OnApplicationPause(bool paused)
    {
        if (!paused)
        {
            return;
        }

        Proxy proxy = new Proxy();
        string[] json= { };
        string path = Application.persistentDataPath + "/hatches.json";
        int i = 0;
        foreach (Hatch hatch in hatches)
        {
            proxy.description = hatch.description;
            proxy.location = hatch.location;
            proxy.state = State.unDrawed;
            json[i] = JsonUtility.ToJson(proxy);
            i++;
        }
        File.WriteAllLines(path, json);
    }
    public void testing()
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

        string path = Application.persistentDataPath + "/hatches.json";

        
        
    }
}

