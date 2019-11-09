using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Skin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject skin;
    [SerializeField]
    private float _animtime = 1.0f;


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



        //recttransform_1.offsetMin -= new Vector2(0, -10);
        //recttransform_1.offsetMax += new Vector2(0, -100);
        //skin.gameObject.offsetMin = new Vector2(left, bottom);

        //skin.GetComponent<RectTransform>().top = new Vector2(left, bottom);
        //GetComponent<RectTransform>().offsetMax = new Vector2(right, top);
        //SceneManager.LoadScene("Title_");
    }
    }
