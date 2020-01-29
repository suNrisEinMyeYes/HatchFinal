using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TestJSON : MonoBehaviour
{

    public string description = "ebat ty";

    private void Start()
    {
        SaveToString();
    }

    public void SaveToString()
    {
        Proxy proxy = new Proxy();
        proxy.description = "123";
        var json = JsonConvert.SerializeObject(proxy);
 
    }
}
