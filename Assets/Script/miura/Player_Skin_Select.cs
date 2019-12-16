using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Skin_Select : MonoBehaviour
{
    //データマネージャーの取得
    private GameObject data_manager = null;
    // ヴァリアブルマネージャー取得
    private Variable_Manager variable_manager = null;
    // プレイヤーのスキンの番号
    private int player_skin_number = 0;
    // プレイヤーの種類
    [SerializeField] private GameObject[] players = null;

    private void Awake()
    {
        data_manager = GameObject.Find("Data_Manager");
        variable_manager = data_manager.GetComponent<Variable_Manager>();
        player_skin_number = variable_manager.GetSetAvatarNumber;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject childObject = Instantiate(players[player_skin_number], gameObject.transform.position, players[player_skin_number].transform.rotation) as GameObject;
        childObject.transform.localScale *= gameObject.transform.localScale.y;
        childObject.transform.parent = this.transform;
    }
}
