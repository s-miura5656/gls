using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewTimeManager : MonoBehaviour
    {
        private IGameData iGameData = null;

        private float gameTimeCount = 0f;

        public void Initialize() 
        {
            iGameData = NewGameManager.Instance;

            iGameData.SetGameTime(0f);
        }

        public void ManagedUpdate() 
        {
            gameTimeCount += Time.deltaTime;

            iGameData.SetGameTime(gameTimeCount);
        }
    }
}


