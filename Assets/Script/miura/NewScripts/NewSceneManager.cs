using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Human.BuildingCrash;

namespace Human.BuildingCrash 
{
    public class NewSceneManager : MonoBehaviour
    {
        private IGetData getData = NewGameManager.Instance;
        private ISetData setData = NewGameManager.Instance;

        public void Initialize()
        {
            
        }

        public void ManagedUpdate()
        {
            switch (getData.GetSceneState)
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


