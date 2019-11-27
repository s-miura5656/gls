using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenSet : MonoBehaviour
{

    //最初に作った画面のwidth
    private float default_width = 9.0f;

    //最初に作った画面のheight
    private float default_height = 16.0f;

    void Start()
    {
        //camera.mainを変数に格納
        Camera main_camera = Camera.main;

        //最初に作った画面のアスペクト比 
        float default_aspect = default_width / default_height;

        //実際の画面のアスペクト比
        float actual_aspect = (float)Screen.width / (float)Screen.height;

        //実機とunity画面の比率
        float ratio = actual_aspect / default_aspect;

        //サイズ調整
        main_camera.orthographicSize /= ratio;

    }
}
