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
    private int coin_score;

    private Text coin_score_text;
    private int score = 0;

    private Variable_Manager coin_script;



    void Start()
    {
        Coinget_Manager();
        coincount = GameObject.Find("Data_Manager");
        coin_script = coincount.GetComponent<Variable_Manager>();
        coin_score = coin_script.GetSetCoin;
    }

    // Update is called once per frame
    void Update()
    {
        coin_score_text = crash_score.
            GetComponent<Text>();
        coin_score_text.text = "  " + coin_score;
    }

    public void Coinget_Manager()
    {
        score = 0;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            coin_score,                  // 最終的な値
            3.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }
}

//Coinget_Manager() の最終的な値に　コインの獲得枚数を入れてください

