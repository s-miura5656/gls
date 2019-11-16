using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_camera : MonoBehaviour
{
    // メインカメラを取得
    private Camera cam_main;
    // カメラが離れる速度
    private float scroll_leave = 1f;
    // カメラが近づく速度
    private float scroll_approach = 5f;
    // 現在の視野角
    private float view;
    // マウスを左クリックした場所
    private Vector3 start_pos;
    // マウスの左クリックを放した場所
    private Vector3 end_pos;
    // マウスの移動距離
    private float dist;

    void Start()
    {
        cam_main = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの移動量を決めるマウスの始点
            start_pos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            // マウスの移動量を決めるマウスの終点
            end_pos = Input.mousePosition;

            // マウスの移動量
            dist = (start_pos - end_pos).magnitude;

            // 引っ張り上限
            if (dist >= 200.0f)
            {
                dist = 200.0f;
            }
            // 引っ張り下限
            if (dist <= 30.0f)
            {
                dist = 30.0f;
            }

            // カメラの引きの引く移動速度
            scroll_leave = dist / 100f;

            // カメラの寄りの寄る移動速度
            scroll_approach = dist / 100f;

            // 現在の視野角に引く速度を足してカメラを引く
            view = cam_main.fieldOfView + scroll_leave;
            cam_main.fieldOfView = Mathf.Clamp(value: view, min: 60f, max: 90f);
        }
        else
        {
            // カメラの視野角に寄る速度を足してカメラを寄させる
            view = cam_main.fieldOfView - scroll_approach;
            cam_main.fieldOfView = Mathf.Clamp(value: view, min: 60f, max: 90f);
        }
    }
}
