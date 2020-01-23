using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartHint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        Vector3 vec = new Vector3(transform.eulerAngles.x+90, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.eulerAngles = vec;
    }
}
