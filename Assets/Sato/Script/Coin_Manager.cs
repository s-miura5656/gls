using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Coin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject crash_score;
    private GameObject coincount;
    public int coin_score;
    private Text coin_score_text;
    public int score = 0;
    private Variable_Manager coin_script;


    private GameObject Date_Object;
    [SerializeField]
    private Text Date_text;
    private int before_score;
    public int after_score;
    [SerializeField]
    private GameObject text_date;


    void Start()
    {
        
        coincount = GameObject.Find("Data_Manager");
        coin_script = coincount.GetComponent<Variable_Manager>();
        coin_score = coin_script.GetSetCoin;
        Coinget_Manager();
    }

    // Update is called once per frame
    void Update()
    {
        coin_score_text = crash_score.GetComponent<Text>();
        coin_score_text.text = score.ToString();
        
    }

    public void Coinget_Manager()
    {
        score = 0;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            coin_score,                  // 最終的な値
            2.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }

    //public int GetSetScore
    //{
    //    get { return score; }
    //    //set { score = value; }
    //}


    public void Calculation_Manager()
    {
 
        after_score = coin_score * 2;
        AftterGet_Manager();
        NewCoin_Manager();


    }

    public void AftterGet_Manager()
    {
        //   before_score = before_score;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            after_score,                  // 最終的な値
            5.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }

    public void NewCoin_Manager()
    {
        //Date_text = text_date.GetComponent<Text>();
        //Date_text.text = "  " + before_score;
    }
}

//Coinget_Manager() の最終的な値に　コインの獲得枚数を入れてください

