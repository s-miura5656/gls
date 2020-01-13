using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Finger_Move : MonoBehaviour
{

    [SerializeField]
    private RectTransform play_button;
    [SerializeField]
    private Image finger_mark;
    [SerializeField]
    private RectTransform finger_image;

    [SerializeField]
    private float scale = 1.0f;

    void Start()
    {
        //// DoTweenのシーケンス作成。
        //Sequence seq = DOTween.Sequence();
        //// シーケンスの繰り返す回数をセット、-1で無限ループ
        //seq.SetLoops(-1);
        //// シーケンスに拡大処理を追加。
        //seq.Append(finger_image.DOScale(new Vector3(1.28f, 1.28f, 1.28f), 0.7f));
        //// シーケンスに拡縮処理を追加。
        //seq.Append(finger_image.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.0f));

        DOTween.ToAlpha(
               () => finger_mark.color,
               color => finger_mark.color = color,
               0.0f, // 目標値
               scale // 所要時間
                     //Random.Range(0.0f, 0.2f), // 目標値
                     //Random.Range(0.5f, 0.5f) // 所要時間
           ).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
