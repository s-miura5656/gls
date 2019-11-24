using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CrashScore_Manager : MonoBehaviour

{
    [SerializeField]
    private GameObject crash_score;

    private GameObject date;


    private Variable_Manager script;

    private float score = 0;


    private Text crash_score_text;


    public float crash_count;
    private int test_count;

    private int crash_rate;



    void Start()
    {
        crash_count = Variable_Manager.Instance.GetSetDestructionRate;
        Crash_Manager();
        Crash_Bonusew();

    }

    // Update is called once per frame
    void Update()
    {
        crash_score_text = crash_score.GetComponent<Text>();
        crash_score_text.text =score.ToString("f2") + " ％" ;
    }

    public void Crash_Manager()
    {
        score = 0;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            crash_count,           // 最終的な値
            5.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }


    public void Crash_Bonusew()
    {
        //if(crash_count >= 0 && crash_count > 10)
        //{
        //    crash_rate = 0;
        //}

        //else if(crash_count >= 10 && crash_count > 20)
        //{
        //    crash_rate = 10;
        //}

        //else if (crash_count >= 20 && crash_count > 30)
        //{
        //    crash_rate = 20;
        //}

        //else if (crash_count >= 30 && crash_count > 40)
        //{
        //    crash_rate = 30;
        //}

        //else if (crash_count >= 40 && crash_count > 50)
        //{
        //    crash_rate = 40;
        //}

        //else if (crash_count >= 50 && crash_count > 60)
        //{
        //    crash_rate = 50;
        //}

        //else if (crash_count >= 60 && crash_count > 70)
        //{
        //    crash_rate = 60;
        //}

        //else if (crash_count >= 70 && crash_count > 80)
        //{
        //    crash_rate = 70;
        //}

        //else if (crash_count >= 80 && crash_count > 90)
        //{
        //    crash_rate = 80;
        //}

        //else if (crash_count >= 90 && crash_count <= 100)
        //{
        //    crash_rate = 90;
        //}





    }


}


