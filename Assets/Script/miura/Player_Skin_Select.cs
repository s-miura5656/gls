using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Skin_Select : MonoBehaviour
{
    // プレイヤースキン種類
    [SerializeField] private GameObject[] players = null;
    
    void Start()
    {
        GameObject childObject = Instantiate(players[Variable_Manager.Instance.GetSetAvatarNumber], 
                                             gameObject.transform.position, 
                                             players[Variable_Manager.Instance.GetSetAvatarNumber].transform.rotation) as GameObject;

        childObject.transform.localScale *= gameObject.transform.localScale.y;
        childObject.transform.parent = this.transform;
    }
}
