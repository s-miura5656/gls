﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class PlayButton_Move : MonoBehaviour
{
    [SerializeField]
    private RectTransform play_button;

    void Start()
    {
        

            // DoTweenのシーケンス作成。
            Sequence seq = DOTween.Sequence();
            // シーケンスの繰り返す回数をセット、-1で無限ループ
            seq.SetLoops(-1);
            // シーケンスに拡大処理を追加。
            seq.Append(play_button.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 1.0f));
            // シーケンスに拡縮処理を追加。
            seq.Append(play_button.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
