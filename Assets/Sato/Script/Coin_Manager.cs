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

    [SerializeField]
    private CrashScore_Manager CrashScore_Manager;
    private float crash_score_rate;
    private int crash_rate;

    private bool score_count = false;


    void Start()
    {

        coincount = GameObject.Find("Data_Manager");
        coin_script = coincount.GetComponent<Variable_Manager>();
        coin_score = coin_script.GetSetCoin;
        crash_score_rate = CrashScore_Manager.crash_count;

        Coinget_Manager();
    }

    // Update is called once per frame
    void Update()
    {
        coin_score_text = crash_score.GetComponent<Text>();
        coin_score_text.text = score.ToString();

        if(score_count == true)
        {
            CrashRate_Get();
        }
    }

    public void Coinget_Manager()
    {
        score = 0;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            coin_score,                  // 最終的な値
            5.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);


        score_count = true;
    }

    //public int GetSetScore
    //{
    //    get { return score; }
    //    //set { score = value; }
    //}




    public void CrashRate_Get()
    {
        //if (crash_score_rate >= 0 && crash_score_rate > 10)
        //{
        //    coin_score += 0;
        //}

        //else if (crash_score_rate >= 10 && crash_score_rate > 20)
        //{
        //    coin_score += 10;
        //}

        //else if (crash_score_rate >= 20 && crash_score_rate > 30)
        //{
        //    coin_score += 20;
        //}

        //else if (crash_score_rate >= 30 && crash_score_rate > 40)
        //{
        //    coin_score += 50;
        //}

        //else if (crash_score_rate >= 40 && crash_score_rate > 50)
        //{
        //    coin_score += 75;
        //}

        //else if (crash_score_rate >= 50 && crash_score_rate > 60)
        //{
        //    coin_score += 100;
        //}

        //else if (crash_score_rate >= 60 && crash_score_rate > 70)
        //{
        //    coin_score += 150;
        //}

        //else if (crash_score_rate >= 70 && crash_score_rate > 80)
        //{
        //    coin_score += 250;
        //}

        //else if (crash_score_rate >= 80 && crash_score_rate > 90)
        //{
        //    coin_score += 500;
        //}

        //else if (crash_score_rate >= 90 && crash_score_rate < 100)
        //{
        //    coin_score += 800;
        //}

        //else if (crash_score_rate == 100)
        //{
        //    coin_score += 1000;
        //}


        //DOTween.To(
        //    () => score,          // 何を対象にするのか
        //    num => score = num,   // 値の更新
        //    coin_score,                  // 最終的な値
        //    5.0f                  // アニメーション時間
        //).SetEase(Ease.OutCubic);


    }


    public void Calculation_Manager()
    {

        after_score = coin_score * 2;
        AftterGet_Manager();
        CrashRate_Get();


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
}


