using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin_Serect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] skin_serect;
    [SerializeField]
    private SkinData serect_number;

    private int skin_number;

    //[SerializeField]private Button[] buttons = new Button[9];


    void Start()
    {
        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    int selectNumber = i;
        //    buttons[i].onClick.AddListener(() => SkinSelect(selectNumber));
        //}

        // ゲームオブジェクトを消したいとき
        // buttons[0].gameObject.SetActive(false);

        // コンポーネントを消したいとき
        // buttons[0].enabled = false;



        skin_number = Variable_Manager.Instance.GetSetAvatarNumber;




        for(int i = 0; i< skin_serect.Length; i++)
        {
            skin_serect[i].SetActive(false);
            if (skin_number == i)
            {
               
                skin_serect[i].SetActive(true);
            }



        }
        
    }


    public void SkinSelect(int skinNumber)
    {
        for (int i = 0; i < skin_serect.Length; i++)
        {
            skin_serect[i].SetActive(false);
        }

        skin_serect[skinNumber].SetActive(true);
        Variable_Manager.Instance.GetSetAvatarNumber = skinNumber;
    }
}
