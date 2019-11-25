using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrations_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject vibrations_on;
    [SerializeField]
    private GameObject vibrations_off;
    [SerializeField]
    private Variable_Manager script;

    private bool on_state = true;
    private bool off_state = false;

    private bool status;


    void Awake()
    {
        status = Variable_Manager.Instance.GetSetVibrate;
    }

    private void Start()
    {    
        status = Variable_Manager.Instance.GetSetVibrate;
        Variable_Setting();
    }


    public void Variable_Setting()
    {
        if(status == true)
        {
            vibrations_on.SetActive(true);
            vibrations_off.SetActive(false);
        }

        else if(status == false)
        {
            vibrations_on.SetActive(false);
            vibrations_off.SetActive(true);
        }          
            
    }


    public void Variable_On_Off()
    {

        vibrations_on.SetActive(false);
        vibrations_off.SetActive(true);
        status = false;
        //Variable_Manager.Instance.GetSetVibrate = status;

    }

    public void Variable_Off_On()
    {
        vibrations_on.SetActive(true);
        vibrations_off.SetActive(false);
        status = true;
        //Variable_Manager.Instance.GetSetVibrate = status;

    }

    public bool GetStatus() { return status; }

}
