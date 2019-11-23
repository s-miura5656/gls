using System.Collections;
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
            GetComponent<Renderer>().material.color = skinColors[0];
        }

        else if(avatar_number == 1)
        {
            GetComponent<Renderer>().material.color = skinColors[1];
        }

        else if (avatar_number == 2)
        {
            GetComponent<Renderer>().material.color = skinColors[2];
        }

        else if (avatar_number == 3)
        {
            GetComponent<Renderer>().material.color = skinColors[3];
        }

        else if (avatar_number == 4)
        {
            GetComponent<Renderer>().material.color = skinColors[4];
        }

        else if (avatar_number == 5)
        {
            GetComponent<Renderer>().material.color = skinColors[5];
        }

    }
}
