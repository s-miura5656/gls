using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Debug_play : MonoBehaviour
{
    private GameObject debug_text = null;
    private TextMeshProUGUI text = null;
    // Start is called before the first frame update
    void Start()
    {
        debug_text = GameObject.Find("Debug");
        text = debug_text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + gameObject.transform.position;
    }
}
