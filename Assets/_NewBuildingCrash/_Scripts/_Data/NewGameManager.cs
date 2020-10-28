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
        private float gameTime = 0f;

        public float GetGameTime => gameTime;
        public void SetGameTime(float gametime) { this.gameTime = gametime; }

        public SceneState GetSceneState => sceneState;
        public void SetSceneState(SceneState sceneState) { this.sceneState = sceneState; }
    }

    public interface IGetData
    {
        NewGameManager.SceneState GetSceneState { get; }
        float GetGameTime { get; }
        
    }

    public interface ISetData
    {
        void SetSceneState(NewGameManager.SceneState sceneState);
        void SetGameTime(float gametime);
    }
}


