using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin_Serect : MonoBehaviour
{

    [SerializeField]
    private GameObject[] skin_serect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkinSelect_0()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[0].SetActive(true);
    }

    public void SkinSelect_1()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[1].SetActive(true);
    }

    public void SkinSelect_2()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[2].SetActive(true);
    }

    public void SkinSelect_3()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[3].SetActive(true);
    }

    public void SkinSelect_4()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[4].SetActive(true);
    }

    public void SkinSelect_5()
    {
        for(int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[5].SetActive(true);
    }

    public void SkinSelect_6()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[6].SetActive(true);
    }

    public void SkinSelect_7()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[7].SetActive(true);
    }

    public void SkinSelect_8()
    {
        for (int i = 0; i < 9; i++)
        {
            skin_serect[i].SetActive(false);
        }
        skin_serect[8].SetActive(true);
    }

}
