using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARSessionOrigin))]
public class Drawer : MonoBehaviour
{
    public Text spawn;
    public Text curState;
    public Text postext;
    private ARSessionOrigin m_SessionOrigin;
    public GameObject arCamera;
    public GameObject prefab;
    private Vector3 shift = new Vector3(0f, 0f, 0f);
    public void DrawObject()
    {
        
        for (int i = 0; i < DistanceCalculate.hatches.Count; i++)
        {
            curState.text = DistanceCalculate.hatches[i].state.ToString();
            if (DistanceCalculate.hatches[i].state == State.unDrawed)
            {

                postext.text = DistanceCalculate.hatches[i].position.ToString();

                shift = arCamera.transform.position + DistanceCalculate.hatches[i].position;
                DistanceCalculate.hatches[i].model = Instantiate(prefab, shift, Quaternion.identity);

                spawn.text = "spawned";
                //m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, arCamera.transform.position, Quaternion.identity); //
                //m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, DistanceCalculate.hatches[i].position, Quaternion.identity);//
               
                DistanceCalculate.hatches[i].state = State.drawed;
            }

            if (DistanceCalculate.hatches[i].state == State.toErase)
            {
                Destroy(DistanceCalculate.hatches[i].model);
                DistanceCalculate.hatches[i].state = State.toDelete;
            }
        }
    }

    private void Start()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }
}
