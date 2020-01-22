using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class New_Record : MonoBehaviour
{
    [SerializeField]
    private Text new_record;
    [SerializeField]
    private RectTransform new_record_image;
    [SerializeField]
    private float scale = 1.0f;

    void Start()
    {      
        DOTween.ToAlpha(
               () => new_record.color,
               color => new_record.color = color,
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
