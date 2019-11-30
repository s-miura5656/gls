using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmpleSphere : MonoBehaviour
{
    [SerializeField]
    private GameObject[] SkinObjects;

    private Color smple_color;
    private int avatar_number;


    //private void Awake()
    //{
        
    //    avatar_number = Variable_Manager.Instance.GetSetAvatarNumber;

    //}

    void Start()
    {
        Set_avatar_number();

    }

    void Update()
    {
        

        //if (avatar_number == 0)
        //{
        //    //GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[0]);

        //}

        //else if(avatar_number == 1)
        //{
        //    GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[1]);
        //}

        //else if (avatar_number == 2)
        //{
        //    GetComponent<Renderer>().material.SetColor ("_BaseColor",skinColors[2]);
        //}

        //else if (avatar_number == 3)
        //{
        //    GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[3]);
        //}

        //else if (avatar_number == 4)
        //{
        //    GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[4]);
        //}

        //else if (avatar_number == 5)
        //{
        //    GetComponent<Renderer>().material.SetColor("_BaseColor", skinColors[5]);
        //}

        

    }


    public void Set_avatar_number()
    {
        avatar_number = Variable_Manager.Instance.GetSetAvatarNumber;
        for (int i = 0; i < SkinObjects.Length; i++)
        {
            SkinObjects[i].SetActive(false);
        }
            SkinObjects[avatar_number].SetActive(true);
            
            Variable_Manager.Instance.GetSetAvatarNumber = avatar_number;
        
    }
}
