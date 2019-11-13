using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Loading : MonoBehaviour
{
    // 透明化の速さ
    private float speed = 0.01f;
    // A値を操作するための変数
    private float alpha = 1f;
    // ゲームオブジェクトのカラーコンポーネント
    private Color obj_color;
    // ゲームのカウントダウン開始
    private bool count_down_start = false;
    // 時間のカウント
    private float time_count = 0f;
    // Start is called before the first frame update
    void Start()
    {
        obj_color = gameObject.GetComponent<Image>().color;    
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;

        if (time_count >= 1f)
        {
            AlphaDown();
        }
        
    }

    private void AlphaDown() 
    {
        gameObject.GetComponent<Image>().color = new Color(obj_color.r, obj_color.g, obj_color.b, alpha);

        alpha -= Time.deltaTime / 2f;

        if (alpha <= 0)
        {
            gameObject.SetActive(false);
            count_down_start = true;
        }
    }

    public bool GetCountDownStart() { return count_down_start; }
}
