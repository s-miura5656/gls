using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Skin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject skin;
    [SerializeField]
    private float _animtime = 1.0f;
    [SerializeField]
    private GameObject back_bottom;
    [SerializeField]
    private float botton_animtime = 1.0f;

    private bool count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void PlayGame()
    {
        //RectTransform rectTransform = skin.GetComponent<RectTransform>();



        var recttransform_1 = skin.GetComponent<RectTransform>();
        recttransform_1.DOScaleY(
              0.0f,　　//終了時点のScale
          _animtime 　　　　　　//時間
               );

        var recttransform_2 = back_bottom.GetComponent<RectTransform>();
        recttransform_2.DOScaleY(
              0.0f,　　//終了時点のScale
          _animtime 　　　　　　//時間
               );

        back_bottom.SetActive(false);


        count = false;

        //if(count == false)
        //SceneManager.LoadScene("Title_");
    }
}
