using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Get_Bar : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    public void Stage_Close()
    {
        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(transform.DOScaleY(0.0f, 0.1f));
    }
}