using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    private Vector3 base_pos;
    private Vector3 end_pos;
    private float elapsed_time;
    private float time;
    private float speed;
    private float ratio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Enemy_Move()
    {
        // 時間の経過
        elapsed_time += Time.deltaTime;

        // 始点と終点の距離
        float distance = Vector3.Distance(base_pos, end_pos);

        //Debug.Log(distance);

        time = distance / speed;

        // 指定された時間に対して経過した時間の割合
        if (ratio <= 1)
        {
            ratio = elapsed_time / time;
        }

        // 始点から終点までの移動処理
        transform.position = Vector3.Lerp(base_pos, end_pos, ratio);


    }
}
