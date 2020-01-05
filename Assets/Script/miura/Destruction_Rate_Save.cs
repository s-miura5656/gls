﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Rate_Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Variable_Manager.Instance.GetSetDestructionRate > PlayerPrefs.GetFloat("Stage_" + Variable_Manager.Instance.Serect_Stage +
                                                                                   "_DestructionRateMax_" + Variable_Manager.Instance.GetSetStageLevel))
        {
            PlayerPrefs.SetFloat(("Stage_" + Variable_Manager.Instance.Serect_Stage + 
                                  "_DestructionRateMax_" + Variable_Manager.Instance.GetSetStageLevel), Variable_Manager.Instance.GetSetDestructionRate);
        }
    }
}