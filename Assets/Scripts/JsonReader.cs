
using System.Collections.Generic;

using System.IO;
using Newtonsoft.Json;
//using System.Text.Json.Serialization;
//using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;




public class JSONReader : MonoBehaviour
{
    public static List<Hatch> hatches = new List<Hatch>();

    public Text lats;
    public static int Size;

    private bool isWritten = false;


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
    }

    private void OnApplicationPause(bool paused)
    {
        if (paused && isWritten)
        {
            isWritten = false;
        }
        else if (!paused || isWritten)
        {
            return;
        }


        Proxy proxy = new Proxy();


        List<string> json = new List<string>();

        string path = Application.persistentDataPath + "/hatches.json";


        foreach (Hatch hatch in hatches)
        {
            proxy.description = hatch.description;
            proxy.location.latitude = hatch.location.latitude;
            proxy.location.longitude = hatch.location.longitude;
            proxy.state = State.unDrawed;
            json.Add(JsonConvert.SerializeObject(proxy));
        }

        File.WriteAllLines(path, json);
        isWritten = true;
    }
}

