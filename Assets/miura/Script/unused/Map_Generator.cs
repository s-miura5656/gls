using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    // 移動のための位置保存用
    private float[] map_pos_x;
    private float[] map_pos_z;
    // ブロックのゲームオブジェクト
    private GameObject block;
    // 壁のオブジェクト
    private GameObject wall;
    // 配列番号指定用
    private int pos_number_x;
    private int pos_number_z;


    // Start is called before the first frame update
    void Start()
    {
        block = (GameObject)Resources.Load("Wall_Block");
    }

    // Update is called once per frame
    void Update()
    {
        MoveControllerX();
        MoveControllerY();
        SetWallBlock();

        transform.position = new Vector3(pos_number_x, 0.5f, pos_number_z);
    }

    /// <summary>
    /// ブロックの移動X軸
    /// </summary>
    private void MoveControllerX()
    {
        if (Input.GetKeyDown("right"))
        {
            pos_number_x++;
        }

        if (Input.GetKeyDown("left"))
        {
            pos_number_x--;
        }
    }

    /// <summary>
    /// ブロックの移動Y軸
    /// </summary>
    private void MoveControllerY()
    {
        if (Input.GetKeyDown("up"))
        {
            pos_number_z++;
        }

        if (Input.GetKeyDown("down"))
        {
            pos_number_z--;
        }
    }

    /// <summary>
    /// 壁のブロックを生成
    /// </summary>
    private void SetWallBlock()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(block, transform.position, transform.rotation);
        }
    }

    
}
