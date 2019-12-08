using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeruTeru/Create PlayerParametor", fileName = "PlayerParametor")]
public class PlayerParametor : ScriptableObject
{
    [Header("プレイヤーのレベルの最大値")]   [SerializeField] private int player_level_max = 0;
    [Header("プレイヤーのレベル毎の経験値")] [SerializeField] private int[] player_level_up_exp;
    [Header("プレイヤーのレベル毎のサイズ")] [SerializeField] private float[] player_scale;
    [Header("プレイヤーのレベル毎に力を加える力")] [SerializeField] private float[] player_powor;

    public int PlayerLevelMax 
    {
        get { return player_level_max; }
    }
    
    public int[] PlayerLevelUpExp 
    {
        get { return player_level_up_exp; }
    }

    public float[] PlayerScale 
    {
        get { return player_scale; }
    }

    public float[] PlayerPowor 
    {
        get { return player_powor; }
    }
}
