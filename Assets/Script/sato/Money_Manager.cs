using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money_Manager : MonoBehaviour
{
    [SerializeField]
    private Variable_Manager coin_script;
    [SerializeField]
    private Text coin_text;

    private int possession_coin;

    private void Awake()
    {
        
    }


    void Start()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        coin_text.text = possession_coin.ToString();
    }

    
    void Update()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        coin_text.text = possession_coin.ToString();
    }
}
