using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class clicker : MonoBehaviour
{
    //public Text debug; 
    //private GameObject temp;
    public Canvas canv;
    public Text main;
    //
    //public Hatch abc;
   // public InputField inp;
    //public Button but;
    public InputField mark;
    public Text input;
    public Text debug;
    private Hatch temp;
   

    // Start is called before the first frame update
    void Awake()
    {
        //canv = GameObject.Find("Canvas");
        //debug.text = canv.gameObject.activeInHierarchy.ToString();
    }

    public void check()
    {

        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                //main.text = raycastHit.collider.gameObject.name.ToString() + " " + raycastHit.collider.gameObject.tag.ToString() ;
                canv.gameObject.SetActive(true);
                temp = raycastHit.collider.gameObject.GetComponent<Hatch>();
                main.text = temp.description;
            }
            
        }
            
        
    }

    public void close()
    {
        temp.description = main.text;
        int k = 0;
        foreach (Hatch hatch in JSONReader.hatches)
        {
            if (temp.location.latitude == hatch.location.latitude && temp.location.longitude == hatch.location.longitude)
            {
                //debug.text = "ZAEBAL "+ k.ToString();
                JSONReader.hatches[k].description = temp.description;
            }
            k++;
        }
        k = 0;
        foreach (Hatch hatch in DistanceCalculate.hatches)
        {
            if (temp.location.latitude == hatch.location.latitude && temp.location.longitude == hatch.location.longitude)
            {
                //debug.text = "ZAEBAL "+ k.ToString();
                DistanceCalculate.hatches[k].description = temp.description;
            }
            k++;
        }
        canv.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        check();
    }

    public void OnChange()
    {
        main.text = main.text + '\n' + mark.text;
        input.text = "Enter text...";
        mark.text = "";
       // foreach (Hatch hatch in JSONReader.hatches)
        //{
            //hatch.description = main.text;
            //hatch.state = State.unDrawed;
            //hatch.distance = 0;
            //hatch.position = Vector3.zero;
        //}
    }
    //private void OnApplicationQuit()
    //{
        
        

    //}
}


