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
