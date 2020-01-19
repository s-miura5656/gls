using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpSkinData
{
    public static readonly int SpSkinNumber = 6;
    private static readonly string SaveSpSkinBuyKey = "buy_sp_skin_";

    private bool[] sp_skine_open = new bool[SpSkinNumber];

    public bool[] SpSkinOpen
    {
        get { return sp_skine_open; }
        set { sp_skine_open = value; }
    }

    public void SpSkinDataLoad()
    {
        for (int i = 0; i < sp_skine_open.Length; i++)
        {
            var buySpSkin = PlayerPrefs.GetString(SaveSpSkinBuyKey + i);

            sp_skine_open[i] = false;

            if (buySpSkin == "buy_sp")
            {
                sp_skine_open[i] = true;
            }
        }
    }

    public void SpSkinDataSave()
    {
        for (int i = 0; i < sp_skine_open.Length; i++)
        {
            if (sp_skine_open[i])
            {
                PlayerPrefs.SetString(SaveSpSkinBuyKey + i, "buy_sp");
            }
            else
            {
                PlayerPrefs.SetString(SaveSpSkinBuyKey + i, "not_buy_sp");
            }
        }
    }
}
