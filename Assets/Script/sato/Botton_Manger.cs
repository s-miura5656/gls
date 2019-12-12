using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Botton_Manger : MonoBehaviour
{
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private float push_scale = 2.0f;
    [SerializeField]
    private float push_animtime = 1.0f;
    [SerializeField]
    private float leave_animtime = 1.0f; 
    [SerializeField]
    private float leave_scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushBotton()
    {
        var recttransform_2 = back.GetComponent<RectTransform>();
        recttransform_2.DOScale(
              push_scale,　　//終了時点のScale
          push_animtime 　　　　　　//時間
               ).SetEase(Ease.Linear);
    }

    public void LeaveBotton()
    {
        var recttransform_2 = back.GetComponent<RectTransform>();
        recttransform_2.DOScale(
             leave_scale,　　//終了時点のScale
        leave_animtime  //時間
               ).SetEase(Ease.InCirc);
    }
}
