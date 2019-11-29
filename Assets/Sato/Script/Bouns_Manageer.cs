using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouns_Manageer : MonoBehaviour
{
    //[SerializeField]
    //private Text crash_score;
    //[SerializeField]
    //private Variable_Manager script;

    private float crash_late;



    void Start()
    {
        crash_late = Variable_Manager.Instance.GetSetDestructionRate;

    }


    void Update()
    {

    }

    
}
