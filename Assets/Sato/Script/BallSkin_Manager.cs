using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallSkin_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] ball;
    [SerializeField]
    private GameObject skin_ball;

    private Image skin_Image;
    private Image Original_Image;

    void Start()
    {
        skin_Image = skin_ball.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnSkin()
    {

            Original_Image = GetComponent<Image>();
            skin_Image.sprite = Original_Image.sprite;

    }

}
