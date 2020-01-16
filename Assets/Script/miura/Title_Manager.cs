using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;



public class Title_Manager : MonoBehaviour
{
    [SerializeField] private Button open_button = null;
    [SerializeField] private Button close_button = null;
    [SerializeField] private Button[] stage_select_buttons = {null};
    [SerializeField] private GameObject stage_select_obj = null;
    public int game_start = 0;

    [SerializeField] private ExclamationMark_Move ex_scrpt;

    // アニメの時間
    private float anime_time = 0.2f;
    // ステージナンバー(最大)
    private int max_stage_number = 9;
    // ゲームメインのシーン
    private Scene game_main;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        game_start = Variable_Manager.Instance.GetSetPlayGames;

        open_button.onClick.AddListener(OpenStageSelect);
        close_button.onClick.AddListener(CloseStageSelect);

        for (int i = 0; i < stage_select_buttons.Length; i++)
        {
            int v = i;
            stage_select_buttons[i].onClick.AddListener(() => StageSelect(v));
        }
    }

    [System.Obsolete]
    private IEnumerator AddScene() 
    {
        while (!game_main.isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(game_main);
        SceneManager.UnloadScene(SceneManager.GetSceneByName("Title_1"));
    }

    private GameObject StageGanarator(int stage_number)
    {
        UnityAnaltics.Instance.Skin_now(Variable_Manager.Instance.GetSetAvatarNumber);

        GameObject stage;

        stage = Instantiate(Resources.Load("Prefabs/GameMain/Stage/Game_" + (stage_number + 1)) as GameObject);
        
        return stage;
    }

    [System.Obsolete]
    private void ChangeGameMain(int stage_number) 
    {
        if (UnityEngine.Rendering.SplashScreen.isFinished)
        {
            ex_scrpt.Mark_Off();

            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            game_main = SceneManager.GetSceneByBuildIndex(1);

            SceneManager.MoveGameObjectToScene(StageGanarator(stage_number), game_main);
            Variable_Manager.Instance.Serect_Stage = stage_number;

            StartCoroutine(AddScene());
        }
    }

    [System.Obsolete]
    private void StageSelect(int number)
    {
        UnityAnaltics.Instance.Stage_Serect(number);
        UnityAnaltics.Instance.Skin_now(Variable_Manager.Instance.GetSetAvatarNumber);
        Variable_Manager.Instance.Serect_Stage = number;
        ChangeGameMain(number);
    }

    [System.Obsolete]
    private void OpenStageSelect()
    {
        Sequence seq = DOTween.Sequence();

        // アニメーション追加
        seq.Append(stage_select_obj.transform.DOScaleY(1.0f, anime_time));

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

    private void CloseStageSelect()
    {
        Sequence seq = DOTween.Sequence();

        // アニメーション追加
        seq.Append(stage_select_obj.transform.DOScaleY(0.0f, anime_time));

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
