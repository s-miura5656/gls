using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Loading : MonoBehaviour
{
    // アニメーションを映すRawimage
    [SerializeField] private GameObject finger_raw_image = null;
    // アニメーションに関係するオブジェクトを持っているオブジェクト
    [SerializeField] private GameObject finger_anime_set;
    // アニメーション用のボール
    [SerializeField] private GameObject ball_fake = null;
    // アニメーション用の指のSpriteオブジェクト
    [SerializeField] private GameObject finger = null;
    // ゲームのカウントダウン開始
    private bool count_down_start = false;
    // アニメーション用のボールの初期位置
    private Vector3 default_ball_fake_pos = new Vector3(0f, 0f, 0f);
    // アニメーション用の指の初期位置
    private Vector3 default_finger_pos = new Vector3(0f, 0f, 0f);
    // アニメーション中のステート
    private int explanation_anime_state = 0;
    // 指定回数アニメーションさせる
    private int anime_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        default_ball_fake_pos = ball_fake.transform.position;
        default_finger_pos = finger.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (explanation_anime_state == 0)
        {
            if (finger.transform.position.y >= 195f)
            {
                finger.transform.position -= new Vector3(0f, 0.1f, 0f);
            }
            else
            {
                explanation_anime_state = 1;
            }
        }

        if (explanation_anime_state == 1)
        {
            if (ball_fake.transform.position.y <= 208f)
            {
                ball_fake.transform.position += new Vector3(0f, 0.1f, 0f);
            }
            else
            {
                ball_fake.transform.position = default_ball_fake_pos;
                finger.transform.position = default_finger_pos;
                explanation_anime_state = 0;
                anime_count++;
            }
        }

        if (anime_count > 2)
        {
            LodingEnd();
        }

    }

    private void LodingEnd() 
    {
        gameObject.SetActive(false);
        finger_anime_set.SetActive(false);
        finger_raw_image.SetActive(false);
        count_down_start = true;
    }

    public bool GetCountDownStart() { return count_down_start; }
}
