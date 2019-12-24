using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARSessionOrigin))]
public class Drawer : MonoBehaviour
{
    public Text spawn;
    public Text curState;
    private ARSessionOrigin m_SessionOrigin;
    public GameObject arCamera;

    public void DrawObject()
    {
        for (int i = 0; i < DistanceCalculate.hatches.Count - 1; i++)
        {
            curState.text = DistanceCalculate.hatches[i].state.ToString();
            if (DistanceCalculate.hatches[i].state == State.unDrawed)
            {
                DistanceCalculate.hatches[i].state = State.drawed;
                DistanceCalculate.hatches[i] = Instantiate(DistanceCalculate.hatches[i].model, Vector3.zero, Quaternion.identity);
                m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, arCamera.transform.position, Quaternion.identity);
                m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, DistanceCalculate.hatches[i].position, Quaternion.identity);
                spawn.text = "spawned";
            }

            if (DistanceCalculate.hatches[i].state == State.toErase)
            {
                Destroy(DistanceCalculate.hatches[i].gameObject);
                DistanceCalculate.hatches[i].state = State.toDelete;
            }
        }
    }

    private void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }
}
