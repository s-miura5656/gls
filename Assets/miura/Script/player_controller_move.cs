using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_move : MonoBehaviour
{
    Rigidbody rb;
    // 引っ張りの始点
    private Vector3 startPos;
    // 離したときにプレイヤーにかける力
    private Vector3 startDirection;
    // 離したときにプレイヤーにかける力に追加する値
    private float powor = 1000;
   
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0))
        {
            this.rb.velocity = Vector3.Normalize(this.rb.velocity) * 3.0f;
            this.startPos = Input.mousePosition;
            startDirection *= 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.rb.velocity = Vector3.zero;
            Vector3 endPos = Input.mousePosition;
            startDirection = -1 * (endPos - startPos).normalized;
            rb.AddForce(new Vector3(startDirection.x * powor, 0f, startDirection.y * powor), ForceMode.Impulse);
        }
    }
}
