using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Finger : MonoBehaviour
{
    private RectTransform rect_transform = null;
    private Vector3 default_pos = new Vector3(0f, 0f, 0f);

    void Start()
    {
        rect_transform = GetComponent<RectTransform>();
        default_pos = rect_transform.transform.localPosition;
    }
        // Update is called once per frame
    void FixedUpdate()
    {
        rect_transform.transform.position -= new Vector3(0f, 1f, 0f);

        if (rect_transform.transform.localPosition.y <= -600f)
        {
            rect_transform.transform.localPosition = default_pos;
        }
    }
}
