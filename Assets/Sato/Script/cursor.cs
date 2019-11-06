using UnityEngine;
using System.Collections;

public class GenerateLR : MonoBehaviour
{

    void Start()
    {
        GameObject newLine = new GameObject("Line");
        LineRenderer lRend = newLine.AddComponent<LineRenderer>();
        lRend.SetVertexCount(2);
        lRend.SetWidth(0.2f, 0.2f);
        Vector3 startVec = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 endVec = new Vector3(5.0f, 5.0f, 0.0f);
        lRend.SetPosition(0, startVec);
        lRend.SetPosition(1, endVec);
    }

    void Update()
    {

    }
}
