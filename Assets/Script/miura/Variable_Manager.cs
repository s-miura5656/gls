using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : SingletonMonoBehaviour<Variable_Manager>
{
    // ゲットしたコイン
    private int get_coin = 0;
    // 今回の破壊率
    private float destruction = 0f;
    // スキン番号
    private int avatar_number = 0; //save
    // 所持コイン枚数
    private int possession_coin = 0; //save
    // 振動のON,OFF
    private bool vibrate_state = true;
    // スキンデータ
    private SkinData skinData = null;
    //play回数
    private int play_games = 0;
    //スキンのオープン数
    private int skin_open = 0;
    // 毎回ゲーム起動初回時に簡単なステージが選択されるステート
    private bool stage_state = false;


    // スキンの解放確認1
    private bool[] Lock_image = new bool[SkinData.SkinNumber];
    // スキンの解放確認2
    private bool[] key_image = new bool[SkinData.SkinNumber];

    public float play_time = 0;

    //[SerializeField]
    //private UnityAnaltics ana_script;




    /// <summary>
    /// ゲットしたコイン数
    /// </summary>
    public int GetSetCoin
    {
        get { return get_coin; }
        set { get_coin = value; }
    }

    /// <summary>
    /// １ゲームの破壊率
    /// </summary>
    public float GetSetDestructionRate
    {
        get { return destruction; }
        set { destruction = value; }
    }

    /// <summary>
    /// スキンの番号
    /// </summary>
    public int GetSetAvatarNumber
    {
        get { return avatar_number; }
        set { avatar_number = value; }
    }

    /// <summary>
    /// 現在の所持コイン
    /// </summary>
    public int GetSetPossessionCoin
    {
        get { return possession_coin; }
        set { possession_coin = value; }
    }

    /// <summary>
    /// 振動の切り替え ON = true, OFF = false
    /// </summary>
    public bool GetSetVibrate 
    {
        get { return vibrate_state; }
        set { vibrate_state = value; }
    }

    /// <summary>
    /// ゲーム起動初回かそうでないか
    /// </summary>
    public bool GetSetStageState
    {
        get { return stage_state; }
        set { stage_state = value; }
    }

    public SkinData GetSkinData
    {
        get { return skinData; }
    }

    public bool[] GetSetLockImage
    {
        get { return Lock_image; }
        set { Lock_image = value; }
    }

    public bool[] GetSetKey_image
    {
        get { return key_image; }
        set { key_image = value; }
    }

    public int GetSetOpenSkin
    {
        get { return skin_open; }
        set { skin_open = value; }
    }

    public int GetSetPlayGames
    {
        get { return play_games; }
        set { play_games = value; }
    }

    public void Save()
    {
        skinData.SkinDataSave();

        PlayerPrefs.SetInt("avatar_number", GetSetAvatarNumber);
        PlayerPrefs.SetInt("possession_coin", GetSetPossessionCoin);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("skin_open", GetSetOpenSkin);

        play_time = Time.time;
        Debug.Log(play_time);


        //ana_script.Play_time();
        //ana_script.Skin_now();
        //ana_script.Coin();
        //ana_script.Title();

        UnityAnaltics.Instance.open_number();
        UnityAnaltics.Instance.Play_time();
        UnityAnaltics.Instance.Skin_now();
        UnityAnaltics.Instance.Title();
        UnityAnaltics.Instance.Coin();

    }

    public void Load()
    {
        skinData = new SkinData();
        skinData.SkinDataLoad();

        GetSetAvatarNumber = PlayerPrefs.GetInt("avatar_number");
        GetSetPossessionCoin = PlayerPrefs.GetInt("possession_coin");
        //GetSetPossessionCoin = 100000;
        GetSetOpenSkin = PlayerPrefs.GetInt("skin_open");



        if (GetSetPossessionCoin < 0)
        {
            Debug.LogError("GetSetPossessionCoin=" + GetSetPossessionCoin);
            GetSetPossessionCoin = 0;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            // バックグラウンドに行ったとき
            Debug.Log("バックグラウンドに行った");
            Save();
        }
        else
        {
            // バックグラウンドから戻ってきたとき
            Debug.Log("バックグラウンドから戻った");
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Load();
    }
}
