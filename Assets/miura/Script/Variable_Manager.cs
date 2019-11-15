using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : MonoBehaviour
{
    static public Variable_Manager instance;

    // クラスがついてるオブジェクト
    private GameObject player;

    // 持ってきたいクラス
    private Player_Exp_Get player_exp;

    // Variable_Managerで保持したい変数
    private int exp = 0;



    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        player_exp = player.GetComponent<Player_Exp_Get>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ゲームメインでのコインの数
    /// </summary>
    /// <returns></returns>
    public int GetPlayerExp() { exp = player_exp.GetExp(); return exp; }
}
