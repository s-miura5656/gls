using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_Text_False : MonoBehaviour
{
    // 出てからの時間のカウント
    private float time_count = 0f;
    // 消えるまでの時間
    private float time_invisible = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間たったら非表示
        time_count += Time.deltaTime;

        if (time_count >= time_invisible)
        {
            time_count = 0f;
            gameObject.SetActive(false);
        }
    }
}
