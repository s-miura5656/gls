using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Special_Skin_RandomSerect : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Lock_image;
    [SerializeField]
    private GameObject[] key_image;
    [SerializeField]
    private Image sold_out;
    [SerializeField]
    private Image block_button;

    private int[] random_index;
    private int skin_rest;


    [SerializeField]
    private Button randam_button;
    private int possession_coin;
    [SerializeField]
    private GameObject block_buttton;


    private int[] skin_number;

    private bool skin_open;

    private int open_numbers = 0;

    private int sp_skin_all_open = 0;

    private int skin_buy = 10000;



    void Start()
    {

        int sp_number_Length = Variable_Manager.Instance.GetSpSkinData.SpSkinOpen.Length;
        open_numbers = Variable_Manager.Instance.Sp_GetSetOpenSkin;
        sp_skin_all_open = Variable_Manager.Instance.Sp_Skin_All;

        for (int i = 0; i < sp_number_Length; i++)
        {
            skin_open = Variable_Manager.Instance.GetSpSkinData.SpSkinOpen[i];

            //画面のスキンを全て開放した際の処理
            if (sp_skin_all_open == 1)
            {
                randam_button.interactable = false;
                block_button.gameObject.SetActive(true);
                sold_out.gameObject.SetActive(true);
                randam_button.gameObject.SetActive(false);
            }


            if (skin_open == true)
            {
                Lock_image[i].SetActive(false);
                key_image[i].SetActive(false);
            }
            else
            {
                Lock_image[i].SetActive(false);
                key_image[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        if (possession_coin < skin_buy)
        {
            block_buttton.SetActive(true);
        }

        else if (possession_coin >= skin_buy)
        {
            block_buttton.SetActive(false);
        }
    }

    public void Clik_Random()
    {

        Variable_Manager.Instance.GetSetPossessionCoin -= skin_buy;
        open_numbers++;
        Variable_Manager.Instance.Sp_GetSetOpenSkin = open_numbers;
        randam_button.interactable = false;

        // 解放済みのスキンの数を数える
        random_index = new int[key_image.Length];
        skin_rest = 0;
        for (int i = 0; i < key_image.Length; i++)
        {
            if (key_image[i].activeInHierarchy)
            {
                random_index[skin_rest] = i;
                skin_rest++;
            }
        }

        // ランダムな順列
        for (int i = 0; i < skin_rest; i++)
        {
            int work = random_index[i];
            int rnd = Random.Range(0, skin_rest);
            random_index[i] = random_index[rnd];
            random_index[rnd] = work;
        }

        StartCoroutine(RandomSelect());
    }


    public int randomcount = 600;
    [Range(0.01f, 1.0f)] public float[] speed = new float[] { };

    public AnimationCurve curve = new AnimationCurve();

    private int preNumber = 0;
    private int nextNumber = 0;

    private IEnumerator RandomSelect()
    {
        for (int i = 0; i < randomcount; i++)
        {
            // 指定した秒数待つ
            yield return new WaitForSecondsRealtime(curve[i % curve.length].value);

            //　選ばれた番号を明るくする
            nextNumber = random_index[i % skin_rest];
            for (int j = 0; j < skin_rest; j++)
            {
                var enable = random_index[j] == nextNumber;
                Lock_image[random_index[j]].SetActive(enable);
            }

            preNumber = nextNumber;
        }

        Lock_image[nextNumber].SetActive(false);
        key_image[nextNumber].SetActive(false);

        Variable_Manager.Instance.GetSpSkinData.SpSkinOpen[nextNumber] = true;

        if (skin_rest != 1)
        {
            randam_button.interactable = true;
        }

        if (skin_rest == 1)
        {
            block_button.gameObject.SetActive(true);
            sold_out.gameObject.SetActive(true);
            randam_button.gameObject.SetActive(false);
            Variable_Manager.Instance.Sp_Skin_All = 1;

        }
    }


}

