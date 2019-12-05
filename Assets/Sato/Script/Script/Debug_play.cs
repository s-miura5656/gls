using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Debug_play : MonoBehaviour
{
    private GameObject debug_text = null;
    private Text text = null;
    // Start is called before the first frame update
    void Start()
    {
        debug_text = GameObject.Find("Debug");
        text = debug_text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + gameObject.transform.position;
    }
}
