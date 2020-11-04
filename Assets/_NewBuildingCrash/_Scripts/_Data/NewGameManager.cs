using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewGameManager : SingletonMonoBehaviour<NewGameManager>, IGameData
    {
        public enum SceneState
        {
            TITLE,
            MAIN,
            RESULT
        }

        private SceneState sceneState = SceneState.TITLE;
        private float gameTime = 0f;

        //! 時間
        public float GetGameTime => gameTime;
        public void SetGameTime(float gametime) { this.gameTime = gametime; }

        //! シーン
        public SceneState GetSceneState => sceneState;
        public void SetSceneState(SceneState sceneState) { this.sceneState = sceneState; }
    }

    public interface IGameData
    {
        NewGameManager.SceneState GetSceneState { get; }
        float GetGameTime { get; }

        void SetSceneState(NewGameManager.SceneState sceneState);
        void SetGameTime(float gametime);
    }
}


