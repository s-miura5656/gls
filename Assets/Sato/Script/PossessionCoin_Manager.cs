using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessionCoin_Manager : MonoBehaviour
{

    
    private Text possession_text;
    [SerializeField]
    private Text get_coin_text;
    private int possession_coin;

    private Variable_Manager script;

    void Start()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        get_coin_text.text = " " + possession_coin;
    }
}
