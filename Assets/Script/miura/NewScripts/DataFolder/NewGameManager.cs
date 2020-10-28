using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewGameManager : SingletonMonoBehaviour<NewGameManager>, IGetData, ISetData
    {
        public enum SceneState
        {
            TITLE,
            MAIN,
            RESULT
        }
        private SceneState sceneState = SceneState.TITLE;
        public SceneState GetSceneState => sceneState;
        public void SetSceneState(SceneState sceneState)
        {
            this.sceneState = sceneState;
        }
        //        GetSceneState => sceneState;
        //        SetSceneState { set { sceneState = value; } }
    }
    public interface IGetData
    {
        NewGameManager.SceneState GetSceneState { get; }
    }
    public interface ISetData
    {
        void SetSceneState(NewGameManager.SceneState sceneState);
    }
}


