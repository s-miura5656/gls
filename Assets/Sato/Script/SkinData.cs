using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinData
{
    private static readonly int SkinNumber = 6;
    private static readonly string SaveSkinBuyKey = "buy_skin_";

    private bool[] skine_open = new bool[SkinNumber];

    public bool[] SkinOpen
    {
        get { return skine_open; }
        set { skine_open = value; }
    }

    public void SkinDataLoad()
    {
        for (int i = 0; i < skine_open.Length; i++)
        {
            var buySkin = PlayerPrefs.GetString(SaveSkinBuyKey + i);

            skine_open[i] = false;

            if (buySkin == "buy")
            {
                skine_open[i] = true;
            }
        }
    }

    public void SkinDataSave()
    {
        for (int i = 0; i < skine_open.Length; i++)
        {
            if (skine_open[i])
            {
                PlayerPrefs.SetString(SaveSkinBuyKey + i, "buy");
            }
            else
            {
                PlayerPrefs.SetString(SaveSkinBuyKey + i, "not_buy");
            }
        }
    }
}
