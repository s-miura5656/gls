using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesTransition_Manager : MonoBehaviour
{
    [SerializeField]
    private Coin_Manager after_score;
    
    private int coin_score;

    public void MainManu()
    {
        //if (after_score.after_score == 0)
        //{
        //    coin_score = after_score.coin_score;
        //}

        //else
        //{
        //    coin_score = after_score.after_score;
        //}

        //Variable_Manager.Instance.GetSetPossessionCoin += coin_score;
        //SceneManager.LoadScene("Title_ 1");
    }
}