using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Text : MonoBehaviour
{
    [SerializeField] private Text debug_obj = null;
    private Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        debug_obj.text = $"{ rb.velocity.magnitude.ToString("f2") }";
    }
}
