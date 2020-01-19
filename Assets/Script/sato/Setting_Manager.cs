using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting_Manager : MonoBehaviour
{
    [SerializeField]
    private float _animtime = 1.0f;


    [SerializeField] private Button closeButton = null;
    [SerializeField] private Transform closeTransform = null;
    [SerializeField] private Button openButton = null;
    [SerializeField] private Transform openTransform = null;



    public int skin_click = 0;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseSetting);
        openButton.onClick.AddListener(OpenSetting);
    }


    private void CloseSetting()
    {


        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(closeTransform.DOScaleY(0.0f, _animtime));

        seq.OnStart(() => {
            // アニメーション開始時によばれる
            Debug.Log("Animation Start");
        });

        seq.OnUpdate(() => {
            // 対象の値が変更される度によばれる
            Debug.Log("Animation Update");
        });

        seq.OnComplete(() => {
            Debug.Log("Animation End");
            seq.Complete();
            // アニメーションが終了時によばれる
        });




    }


    private void OpenSetting()
    {
        //ex_scrpt.Mark_Off();

        if (Variable_Manager.Instance.GetSetPossessionCoin >= 5000)
        {
            skin_click = 1;
            UnityAnaltics.Instance.Skin_Click(skin_click);
        }

        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(openTransform.DOScaleY(1.0f, _animtime));

        seq.OnStart(() => {
            // アニメーション開始時によばれる
            Debug.Log("Animation Start");
        });

        seq.OnUpdate(() => {
            // 対象の値が変更される度によばれる
            Debug.Log("Animation Update");
        });

        seq.OnComplete(() => {
            Debug.Log("Animation End");
            seq.Complete();
            // アニメーションが終了時によばれる
        });



    }

}
