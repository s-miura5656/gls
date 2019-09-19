using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_floor : MonoBehaviour
{
    // 時間のカウント
    private float time;
    // 上がるタイミングの変数
    [SerializeField]
    private float up_time;
    // スイッチがオンかオフかの変数
    private bool up_down_switch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpDownTiming();
    }

    /// <summary>
    /// 床の上がり下がり
    /// </summary>
    private void UpDownTiming()
    {
        time += Time.deltaTime;

        if (up_down_switch == true)
        {
            if (time >= up_time)
            {
                transform.position += new Vector3(0f, -1f, 0f);

                up_down_switch = false;

                time = 0f;
            }
        }
        else if (up_down_switch == false)
        {
            if (time >= up_time)
            {
                transform.position += new Vector3(0f, 1f, 0f);

                up_down_switch = true;

                time = 0f;
            }
        }
    }
}
