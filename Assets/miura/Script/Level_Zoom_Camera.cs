using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Zoom_Camera : MonoBehaviour
{
    // プレイヤーのレベルを取得用
    [SerializeField] GameObject game_manager;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager script;
    // メインカメラを取得
    private Camera main_cam;

    // Start is called before the first frame update
    void Start()
    {
        script = game_manager.GetComponent<Player_Level_Manager>();
        main_cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        main_cam.fieldOfView = main_cam.fieldOfView + 10f; 
    }
}
