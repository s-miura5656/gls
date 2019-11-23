using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessionCoin_Manager : MonoBehaviour
{

    
    private Text possession_text;
    [SerializeField]
    private GameObject get_coin;
    private int possession_coin;

    private Variable_Manager script;

    void Start()
    {

        possession_text = get_coin.GetComponent<Text>();
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        possession_text.text = " " + possession_coin;
        PossessionCoin();
    }

    private void Update()
    {

        
        

    }

    private void PossessionCoin()
    {


    }


}
