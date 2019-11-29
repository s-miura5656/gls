﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessionCoin_Manager : MonoBehaviour
{

    
    private Text possession_text;
    [SerializeField]
    private Text get_coin_text;
    private int possession_coin;

    private Variable_Manager script;



    [SerializeField]
    private GameObject botton_2;
    [SerializeField]
    private Text botton_2_text;
    [SerializeField]
    private GameObject botton_2_image;

    private bool skin2_ID;

    [SerializeField]
    private GameObject botton_3;
    [SerializeField]
    private Text botton_3_text;
    [SerializeField]
    private GameObject botton_3_image;
    private bool skin3_ID;

    [SerializeField]
    private GameObject botton_4;
    [SerializeField]
    private Text botton_4_text;
    [SerializeField]
    private GameObject botton_4_image;
    private bool skin4_ID;

    [SerializeField]
    private GameObject botton_5;
    [SerializeField]
    private Text botton_5_text;
    [SerializeField]
    private GameObject botton_5_image;
    private bool skin5_ID;

    [SerializeField]
    private GameObject botton_6;
    [SerializeField]
    private Text botton_6_text;
    [SerializeField]
    private GameObject botton_6_image;
    private bool skin6_ID;

    private int skin_after_coin;





    void Start()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        //possession_coin = 10000;
        get_coin_text.text = " " + possession_coin;
        skin2_ID = Variable_Manager.Instance.Skin2_Open;
        skin3_ID = Variable_Manager.Instance.Skin3_Open;
        skin4_ID = Variable_Manager.Instance.Skin4_Open;
        skin5_ID = Variable_Manager.Instance.Skin5_Open;
        skin6_ID = Variable_Manager.Instance.Skin6_Open;




    }

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }


    public void Skin_open1000_2()
    {

        if (skin2_ID)
        {
            if (possession_coin >= 1000)
            {
                if (botton_2_image.activeInHierarchy == true)
                {
                    skin_after_coin = possession_coin - 1000;
                    botton_2_image.SetActive(false);
                    botton_2_text.text = "-";
                    get_coin_text.text = " " + skin_after_coin;
                    possession_coin = skin_after_coin;
                }
            }
        }

        else
            botton_2_text.text = "-";
        

    }

    public void Skin_open1000_3()
    {
        if (skin3_ID)
        {
            if (botton_3_image.activeInHierarchy == true)
            {
                if (possession_coin >= 1000)
                {
                    skin_after_coin = possession_coin - 1000;
                    botton_3_image.SetActive(false);
                    botton_3_text.text = "-";
                    get_coin_text.text = " " + skin_after_coin;
                    possession_coin = skin_after_coin;
                }
            }
        }

        else
            botton_3_text.text = "-";

    }



    public void Skin_open1000_4()
    {
        if (skin4_ID)
        {
            if (botton_4_image.activeInHierarchy == true)
            {
                if (possession_coin >= 1000)
                {
                    skin_after_coin = possession_coin - 1000;
                    botton_4_image.SetActive(false);
                    botton_4_text.text = "-";
                    get_coin_text.text = " " + skin_after_coin;
                    possession_coin = skin_after_coin;
                }
            }
        }

        else
            botton_4_text.text = "-";
    }


    public void Skin_open4000()
    {
        if (skin5_ID)
        {
            if (botton_5_image.activeInHierarchy == true)
            {
                if (possession_coin >= 4000)
                {
                    skin_after_coin = possession_coin - 4000;
                    botton_5_image.SetActive(false);
                    botton_5_text.text = "-";
                    get_coin_text.text = " " + skin_after_coin;
                    possession_coin = skin_after_coin;
                }
            }
        }

        else
            botton_5_text.text = "-";
    }




    public void Skin_open5000()
    {

        if (skin6_ID)
        {
            if (botton_6_image.activeInHierarchy == true)
            {
                if (possession_coin >= 5000)
                {
                    skin_after_coin = possession_coin - 5000;
                    botton_6_image.SetActive(false);
                    botton_6_text.text = "-";
                    get_coin_text.text = " " + skin_after_coin;
                    possession_coin = skin_after_coin;
                }
            }
        }

        else
            botton_6_text.text = "-";
    }


}
