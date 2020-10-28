using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainManager : MonoBehaviour
{
    //! TODO: マネージャー群を追加する
    [SerializeField] private NewPlayerManager playerManager = null;
    [SerializeField] private NewStageManager stageManager = null;
    [SerializeField] private NewUiManager uiManager = null;

    void Awake()
    {
        
    }

    void Start()
    {
        uiManager.Initialize();
        playerManager.Initialize();
        stageManager.Initialize();
    }

    void Update()
    {
        uiManager.ManagedUpdate();
        playerManager.ManagedUpdate();
        stageManager.ManagedUpdate();
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        
    }
}
