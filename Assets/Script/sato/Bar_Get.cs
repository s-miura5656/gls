using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Get : MonoBehaviour
{
    [SerializeField]
    private GameObject bar;
    [SerializeField]
    private Canvas canvas;

    private int pos_y = 106;
    private int pos_x = 698;

    private Vector3 bar_pos;
    private Vector3 bar_sca;

    RectTransform rectTransform;

    void Start()
    {
        //        rectTransform = GetComponent<RectTransform>();
        bar.transform.SetParent(canvas.transform);
        //        bar.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, bar.transform.position);

        bar.transform.position = new Vector3(0, 0, 0);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        bar_pos = bar.transform.position;
        bar.transform.localScale = Vector3.one;

        var unko = GameObject.Find("bronze_rank_image").GetComponent<RectTransform>();
        float image_with = unko.sizeDelta.x * unko.localScale.y;
        float image_height = unko.sizeDelta.y * unko.localScale.y;

        bar_pos.x = image_with / 2.0f;
        bar_pos.y = (float)Screen.height - image_height;
        //bar_sca.y += bar_sca.y - 43;
        bar.transform.position = bar_pos;

        //canvas.transform
        //rectTransform.position = new Vector3(0, 0, 0);
        //bar.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //bar_pos.x = pos_y;
        //bar_pos.y = pos_x;
        //bar.transform.position = bar_pos;
    }
}
