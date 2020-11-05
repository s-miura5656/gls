using Human.BuildingCrash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainManager : MonoBehaviour
{
    //! TODO: マネージャー群を追加する
    [SerializeField] private NewPlayerManager playerManager = null;
    [SerializeField] private NewStageManager stageManager   = null;
    [SerializeField] private NewUiManager uiManager         = null;
    [SerializeField] private NewTimeManager timeManager     = null;
    [SerializeField] private NewCameraManager cameraManager = null;

    IGameData iGameData = null;

    void Awake()
    {
        iGameData = NewGameManager.Instance;
    }
    
    void Start()
    {
        timeManager.Initialize();
        playerManager.Initialize();
        uiManager.Initialize();
        cameraManager.Initialize();
        stageManager.Initialize();
    }

    void Update()
    {
        timeManager.ManagedUpdate();
        uiManager.ManagedUpdate();
        playerManager.ManagedUpdate();
        stageManager.ManagedUpdate();
    }

    void FixedUpdate()
    {
        cameraManager.FixedManagedUpdate();
    }

    void LateUpdate()
    {
        uiManager.ManagedLateUpdate();
    }
}
