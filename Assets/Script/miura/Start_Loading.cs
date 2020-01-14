using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Loading : MonoBehaviour
{
    
    // ゲームのカウントダウン開始
    private bool count_down_start = false;
    
    // 時間
    private float count = 0;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        count += Time.deltaTime;

        if (count > 2)
        {
            LodingEnd();
        }
    }

    private void LodingEnd() 
    {
        gameObject.SetActive(false);
        count_down_start = true;
    }

    public bool GetCountDownStart() { return count_down_start; }
}
