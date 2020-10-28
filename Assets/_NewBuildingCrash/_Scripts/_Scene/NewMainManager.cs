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

    IGetData getData = null;

    void Awake()
    {
        getData = NewGameManager.Instance;
    }

    void Start()
    {
        timeManager.Initialize();
        //uiManager.Initialize();
        playerManager.Initialize();
        cameraManager.Initialize();
        //stageManager.Initialize();
    }

    void Update()
    {
        timeManager.ManagedUpdate();
        //uiManager.ManagedUpdate();
        playerManager.ManagedUpdate();
        //stageManager.ManagedUpdate();
    }

    void FixedUpdate()
    {
        cameraManager.FixedManagedUpdate();
    }

    void LateUpdate()
    {
        
    }
}
