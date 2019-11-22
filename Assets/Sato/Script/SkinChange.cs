using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{ 
    [SerializeField]
    EventSystem eventSystem;

    GameObject selectedObj;
    int serect_number;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
                //// コンポーネントにアクセスしたいのでいったん変数に格納
                //selectedObj = eventSystem.currentSelectedGameObject.gameObject;
                //// ボタンのコンポーネントから番号を取得
                //serect_number = selectedObj.GetInstanceID();
            
            
        }
    }
}
