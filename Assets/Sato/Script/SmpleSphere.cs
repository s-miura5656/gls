﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmpleSphere : MonoBehaviour
{
    [SerializeField] private Color[] skinColors;

    private Color smple_color;
    private float avatar_number;



    void Start()
    {
        

    }

    void Update()
    {
        avatar_number = Variable_Manager.Instance.GetSetAvatarNumber;

        if(avatar_number == 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[0]);

=======
            GetComponent<Renderer>().material.color = skinColors[0];
>>>>>>> parent of c107149... リザルト　破壊率導入中
=======
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[0]);

>>>>>>> f4ca3b3d42567f5d953d4cb862655639fb0537aa
        }

        else if(avatar_number == 1)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[1]);
        }

        else if (avatar_number == 2)
        {
            GetComponent<Renderer>().material.SetColor ("_BaseColor",skinColors[2]);
        }

        else if (avatar_number == 3)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[3]);
        }

        else if (avatar_number == 4)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[4]);
        }

        else if (avatar_number == 5)
        {
            GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[5]);
        }

    }
}
