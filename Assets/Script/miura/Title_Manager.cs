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
    // ランダムで選ぶかステージ選択か切り替える
    private bool random_mode = true;
    // ゲームメインのシーン
    private Scene game_main;
    // ステージレベル
    private int stage_level = 0;
    // レベルが上がるのに必要な破壊率
    private float[] destruction_rate_level = new float[2] { 40f, 60f };


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

    [System.Obsolete]
    public void OpenStageSelect()
    {
        ex_scrpt.Mark_Off();

        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        game_main = SceneManager.GetSceneByBuildIndex(1);

        // ランダムかそうでないか
        if (random_mode)
        {
            int random_stage = Random.Range(0, 3);
            StageDecideTheLevel(random_stage);
            SceneManager.MoveGameObjectToScene(StageGanarator(random_stage, PlayerPrefs.GetInt("Stage_" + random_stage + "_Level")), game_main);
        }
        else
        {
            StageDecideTheLevel(Variable_Manager.Instance.Serect_Stage);
            SceneManager.MoveGameObjectToScene(StageGanarator(Variable_Manager.Instance.Serect_Stage, PlayerPrefs.GetInt("Stage_" + Variable_Manager.Instance.Serect_Stage + "_Level")), game_main);
        }

        // ステージレベルごとの破壊率の表示
        Debug.Log(PlayerPrefs.GetFloat("Stage_" + Variable_Manager.Instance.Serect_Stage + "_DestructionRateMax_" + Variable_Manager.Instance.GetSetStageLevel));
        // 現在のステージレベル
        Debug.Log(PlayerPrefs.GetInt("Stage_" + Variable_Manager.Instance.Serect_Stage + "_Level"));

        StartCoroutine(AddScene());
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

    private void StageDecideTheLevel(int stage_number) 
    {
        if (PlayerPrefs.GetInt("Stage_" + stage_number + "_Level") == 2)
        {
            return;
        }

        float stage_destruction_rate = PlayerPrefs.GetFloat("Stage_" + stage_number + "_DestructionRateMax_" + Variable_Manager.Instance.GetSetStageLevel);

        for (int i = 0; i < destruction_rate_level.Length; i++)
        {
            if (stage_destruction_rate > destruction_rate_level[i] && PlayerPrefs.GetInt("Stage_" + stage_number + "_Level") == i)
            {
                stage_level = i + 1;
                Variable_Manager.Instance.GetSetStageLevel = stage_level;
                PlayerPrefs.SetInt("Stage_" + stage_number + "_Level", stage_level);
                break;
            }
        }
    }

    public bool RandomMode 
    {
        set { random_mode = value; }
    }
}
