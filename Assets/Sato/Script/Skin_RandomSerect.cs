using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skin_RandomSerect : MonoBehaviour
{



    int state = 0;
    int lock_image_index = 0;
    int lock_image_count = 0;
    int lock_image_old_count = 0;


    [SerializeField]
    private GameObject[] Lock_image;
    [SerializeField]
    private GameObject[] key_image;

    private int[] random_index;
    private int skin_rest;

    float alpha_Sin;


    [SerializeField]
    private Button randam_button;

    [SerializeField]
    private Text use_coin_text;

    [SerializeField]
    private Variable_Manager coin_script;
    private int possession_coin;
    [SerializeField]
    private GameObject block_buttton;



    void Start()
    {
        

    }

    private void Update()
    {
        possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        if (possession_coin < 3000)
        {
            block_buttton.SetActive(true);
        }

        else if (possession_coin >= 3000)
        {
            block_buttton.SetActive(false);
        }
        

    }

    public void Clik_Random()
    {

        Variable_Manager.Instance.GetSetPossessionCoin -=  3000;
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
            //yield return new WaitForSecondsRealtime(speed[i]);

            // 同じ番号にならないようにする
            //            while (preNumber == nextNumber)
            //            {
            //                nextNumber = Random.Range(0, Lock_image.Length);
            //            }

            //　選ばれた番号を明るくする
            nextNumber = random_index[i % skin_rest];
            for (int j = 0; j < skin_rest; j++)
            {
                var enable = random_index[j] == nextNumber;
                Lock_image[random_index[j]].SetActive(enable);
            }

            ////　選ばれた番号を明るくする
            //for (int j = 0; j < Lock_image.Length; j++)
            //{
            //    var enable = j == nextNumber;
            //    Lock_image[j].SetActive(enable);
            //}

            preNumber = nextNumber;
        }

        Lock_image[nextNumber].SetActive(false);
        key_image[nextNumber].SetActive(false);
        if (skin_rest != 1)
        {
            randam_button.interactable = true;
            

        }

        if (skin_rest == 1)
        {
           
            use_coin_text.text = "SOLD OUT";
            use_coin_text.fontSize = 70;

        }
    }


}

