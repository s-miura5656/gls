using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Human.BuildingCrash;

namespace Human.BuildingCrash 
{
    public class NewSceneManager : MonoBehaviour
    {
        private IGameData getGameData = NewGameManager.Instance;

        public void Initialize()
        {
            
        }

        public void ManagedUpdate()
        {
            switch (getGameData.GetSceneState)
            {
                case NewGameManager.SceneState.TITLE:
                    break;
                case NewGameManager.SceneState.MAIN:
                    break;
                case NewGameManager.SceneState.RESULT:
                    break;
            }
        }
    }
}


