using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skin_Manager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject title;
    //[SerializeField]
    //private GameObject skin;
    [SerializeField]
    private float _animtime = 1.0f;
    //[SerializeField]
    //private GameObject back_bottom;
    //[SerializeField]
    //private float botton_animtime = 1.0f;


    [SerializeField] private Button closeButton = null;
    [SerializeField] private Transform closeTransform = null;
    [SerializeField] private Button openButton = null;
    [SerializeField] private Transform openTransform = null;
    [SerializeField] private Image button_stop;

    private bool count;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseSkin);
        openButton.onClick.AddListener(OpenSkin);
        //button_stop.gameObject.SetActive(false);
    }

    private void CloseSkin()
    {
        //RectTransform rectTransform = skin.GetComponent<RectTransform>();

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


        count = false;

        //if(count == false)
        //SceneManager.LoadScene("Title_");
    }

    private void OpenSkin()
    {
        //RectTransform rectTransform = skin.GetComponent<RectTransform>();

        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(openTransform.DOScaleY(1.0f, _animtime));

        button_stop.gameObject.SetActive(true);

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


        count = false;

        //if(count == false)
        //SceneManager.LoadScene("Title_");
    }
}
