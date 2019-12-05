using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skin_RandomSerect : MonoBehaviour
{


    //private Text possession_text;
    //[SerializeField]
    //private Text get_coin_text;
    //private int possession_coin;

    //private Variable_Manager script;



    //[SerializeField]
    //private GameObject botton_2;
    //[SerializeField]
    //private Text botton_2_text;
    //[SerializeField]
    //private GameObject botton_2_image;

    //private bool skin2_ID;

    //[SerializeField]
    //private GameObject botton_3;
    //[SerializeField]
    //private Text botton_3_text;
    //[SerializeField]
    //private GameObject botton_3_image;
    //private bool skin3_ID;

    //[SerializeField]
    //private GameObject botton_4;
    //[SerializeField]
    //private Text botton_4_text;
    //[SerializeField]
    //private GameObject botton_4_image;
    //private bool skin4_ID;

    //[SerializeField]
    //private GameObject botton_5;
    //[SerializeField]
    //private Text botton_5_text;
    //[SerializeField]
    //private GameObject botton_5_image;
    //private bool skin5_ID;

    //[SerializeField]

    //private GameObject botton_6;
    //[SerializeField]
    //private Text botton_6_text;
    //[SerializeField]
    //private GameObject botton_6_image;
    //private bool skin6_ID;

    //private int skin_after_coin;

    //private bool skin7_ID;
    //private bool skin8_ID;
    //private bool skin9_ID;

    int state = 0;
    int lock_image_index = 0;
    int lock_image_count = 0;
    int lock_image_old_count = 0;


    [SerializeField]
    private GameObject[] Lock_image;
    [SerializeField]
    private GameObject[] key_image;

    float alpha_Sin;






    void Start()
    {
        //possession_coin = Variable_Manager.Instance.GetSetPossessionCoin;
        ////possession_coin = 10000;
        //get_coin_text.text = possession_coin.ToString();
        //skin2_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[1];
        //skin3_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[2];
        //skin4_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[3];
        //skin5_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[4];
        //skin6_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[5];
        //skin7_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[6];
        //skin8_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[7];
        //skin9_ID = Variable_Manager.Instance.GetSkinData.SkinOpen[8];

        StartCoroutine(RandomSelect());

        //for (int i = 0; i < Lock_image.Length; i++) {
        //    Lock_image[i].SetActive(false);
        //}
        //lock_image_count = 0;
        //DOTween.To(
        //    () => lock_image_count,          // 何を対象にするのか
        //    num => lock_image_count = num,   // 値の更新
        //    30,                  // 最終的な値
        //    2.0f                  // アニメーション時間
        //).SetEase(Ease.OutCirc); 
    }

    private void Update()
    {
        //if (state == 0)
        //{
        //    if (lock_image_count > lock_image_old_count)
        //    {
        //        lock_image_old_count = lock_image_count;

        //        Lock_image[lock_image_index].SetActive(false);
        //        lock_image_index = Random.Range(0, Lock_image.Length);
        //        Lock_image[lock_image_index].SetActive(true);


        //    }
        //    if (lock_image_count == 30)
        //    {
                
        //        Lock_image[lock_image_index].SetActive(false);
        //        key_image[lock_image_index].SetActive(false);

        //    }
        //}

        //    if(state == 1)
        //    {
                
        //    }

        //        if (lock_image_count >= 600)
        //        {
        //            state = 1;

        //            lock_image_count = 0;
        //            lock_image_old_count = 0;
        //            DOTween.To(
        //                () => lock_image_count,          // 何を対象にするのか
        //                num => lock_image_count = num,   // 値の更新
        //                5,                  // 最終的な値
        //                10.0f                  // アニメーション時間
        //            ).SetEase(Ease.OutCirc);
        //        }
        //    }
        //}
        //else if (state == 1)
        //{
        //    if (lock_image_count > lock_image_old_count)
        //    {
        //        lock_image_old_count = lock_image_count;

        //        Lock_image[lock_image_index].SetActive(false);
        //        lock_image_index = Random.Range(0, Lock_image.Length);
        //        Lock_image[lock_image_index].SetActive(true);
        //    }


    }

    private void Random_time()
    {
        lock_image_count = 0;
        DOTween.To(
            () => lock_image_count,          // 何を対象にするのか
            num => lock_image_count = num,   // 値の更新
            600,                  // 最終的な値
            3.0f                  // アニメーション時間
        );

    }

    public int randomcount = 6;
    [Range(0.01f, 1.0f)] public float[] speed = new float[] { };

    public AnimationCurve curve = new AnimationCurve();

    private int preNumber = 0;
    private int nextNumber = 0;

    private IEnumerator RandomSelect()
    {
        for (int i = 0; i < randomcount; i++)
        {
            // 指定した秒数待つ
            yield return new WaitForSecondsRealtime(curve[i].value);
            //yield return new WaitForSecondsRealtime(speed[i]);

            // 同じ番号にならないようにする
            while (preNumber == nextNumber)
            {
                nextNumber = Random.Range(0, Lock_image.Length);
            }

            //　選ばれた番号を明るくする
            for (int j = 0; j < Lock_image.Length; j++)
            {
                var enable = j == nextNumber;
                Lock_image[j].SetActive(enable);
            }

            preNumber = nextNumber;
        }
    }
}

