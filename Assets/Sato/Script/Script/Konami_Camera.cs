using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LWRP;

public class Konami_Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool konami_switch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool KonamiSwitch
    {
        get { return konami_switch; }
    }
}
