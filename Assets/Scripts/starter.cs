using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starter : MonoBehaviour
{
    public GameObject hatch;
    // Start is called before the first frame update
    void Start()
    {
       // hatch.SetActive(true);
        Vector3 pos = new Vector3(0f,0f,1f);
        Vector3 pos2 = new Vector3(0f, 0f, -1f);
        Instantiate(hatch, pos, Quaternion.identity);
        Instantiate(hatch, pos2, Quaternion.identity);
    }

    
}
