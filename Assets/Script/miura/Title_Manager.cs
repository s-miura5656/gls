using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;



public class Title_Manager : MonoBehaviour
{
    [SerializeField] private Vibrations_Manager script;
    [SerializeField] private RectTransform stage_select_transform = null;
    [SerializeField] private Button open_button = null;
    private int scene_number = 0;
    private int scene_number_min = 1;
    private int scene_number_max = 4;
    private float anime_time = 0.5f;                                                                                                                                                                   
    public int game_start = 0;

    bool isFinishedSplashScreenAndPassedUpdate = false;


    [SerializeField]
    private UnityAnaltics Ana_script;

    // 最初に選ばれるステージの番号
    private int first_stage = 1;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        game_start = Variable_Manager.Instance.GetSetPlayGames;
        open_button.onClick.AddListener(OpenStageSelect);
    }

    // Update is called once per frame
    void Update()
    {
        //scene_number = Random.Range(scene_number_min, scene_number_max);
        //Debug.Log(scene_number);
    }

    public void PlayGame()
    {

        if (UnityEngine.Rendering.SplashScreen.isFinished)
        {
                
            isFinishedSplashScreenAndPassedUpdate = true;
        }

        if (isFinishedSplashScreenAndPassedUpdate == true)
        {

            //if (!Variable_Manager.Instance.GetSetStageState)
            //{
            //    SceneManager.LoadScene("GameMain_" + first_stage);
            //    Variable_Manager.Instance.GetSetStageState = true;
            //}
            //else
            //{
            //    scene_number = Random.Range(scene_number_min, scene_number_max);

            //    SceneManager.LoadScene("GameMain_" + scene_number);
            //}

            //SceneManager.LoadScene("GameMain_" + scene_number);

            game_start++;
            Variable_Manager.Instance.GetSetPlayGames = game_start;
        }


    }

    public void OpenStageSelect()
    {
        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(stage_select_transform.DOScaleY(1.0f, anime_time));

        seq.OnStart(() => {
            // アニメーション開始時によばれる
            Debug.Log("Animation Start");
        });

        seq.OnUpdate(() => {
            // 対象の値が変更される度によばれる
            Debug.Log("Animation Update");
        });

        seq.OnComplete(() => {
            Debug.Log("Animation End");
            seq.Complete();
            // アニメーションが終了時によばれる
        });
    }
}
