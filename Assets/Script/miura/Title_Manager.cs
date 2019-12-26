using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;



public class Title_Manager : MonoBehaviour
{
    [SerializeField] private Button open_button = null;
                                                                                                                                                                  
    public int game_start = 0;

    [SerializeField] private ExclamationMark_Move ex_scrpt;

    // ステージナンバー(最大)
    private int max_stage_number = 3;
    // ステージレベル(最大)
    private int max_stage_level = 3;
    // 生成するステージを入れるオブジェクト型の変数
    private GameObject[,] stage_;

    Scene game_main;

    int count;

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

    private void Update()
    {
        
    }

    [System.Obsolete]
    public void OpenStageSelect()
    {
        ex_scrpt.Mark_Off();

        //ランダムステージセレクトプログラム入力

        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        game_main = SceneManager.GetSceneByBuildIndex(1);
        SceneManager.MoveGameObjectToScene(StageGanarator(Variable_Manager.Instance.Serect_Stage, 0), game_main);
        IEnumerator add_scene = AddScene();
        StartCoroutine(add_scene);
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


    private GameObject StageGanarator(int stage_number, int stage_level)
    {
        stage_ = new GameObject[max_stage_number, max_stage_level];

        for (int i = 0; i < max_stage_number; i++)
        {
            for (int v = 0; v < max_stage_level; v++)
            {
                if (stage_[i, v] == null)
                {
                    stage_[i, v] = Resources.Load("Prefabs/GameMain/Stage/Game_" + (i + 1) + "_" + (v + 1)) as GameObject;
                }
                else
                {
                    break;
                }
            }
        }

        GameObject stage = Instantiate(stage_[stage_number, stage_level]);

        return stage;
    }
}
