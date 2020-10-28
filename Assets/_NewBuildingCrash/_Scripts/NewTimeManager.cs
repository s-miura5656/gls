using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewTimeManager : MonoBehaviour
    {
        private IGetData getData = null;
        private ISetData setData = null;

        private float gameTimeCount = 0f;

        public void Initialize() 
        {
            getData = NewGameManager.Instance;
            setData = NewGameManager.Instance;

            setData.SetGameTime(0f);
        }

        public void ManagedUpdate() 
        {
            gameTimeCount += Time.deltaTime;

            setData.SetGameTime(gameTimeCount);
        }
    }
}


