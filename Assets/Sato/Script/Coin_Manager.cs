﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Coin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject crash_score;

    private Text crash_score_text;
    private int score = 0;


    void Start()
    {
        Coinget_Manager();
    }

    // Update is called once per frame
    void Update()
    {
        crash_score_text = crash_score.
            GetComponent<Text>();
        crash_score_text.text = "  " + score;
    }

    public void Coinget_Manager()
    {
        score = 0;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            1000,                  // 最終的な値
            3.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }
}

//Coinget_Manager() の最終的な値に　コインの獲得枚数を入れてください

