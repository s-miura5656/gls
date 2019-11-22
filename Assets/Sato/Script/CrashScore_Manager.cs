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


    private float crash_count;
    private int test_count;



    void Start()
    {
        crash_count = Variable_Manager.Instance.GetSetDestructionRate;
        Crash_Manager();

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
            crash_count,                  // 最終的な値
            5.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }
}

//Crash_Manager() の最終的な値に　破壊率を入れてください
