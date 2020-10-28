using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewTimeManager
    {
        private float mainTimeCount = 0f;
        private float retryTimeCount = 0f;

        public float GameTime() 
        {
            mainTimeCount += Time.deltaTime;

            return mainTimeCount;
        }

        public void ResetGameTime() 
        {
            mainTimeCount = 0f;
        }

        public float RetryTime() 
        {
            retryTimeCount += Time.deltaTime;

            return retryTimeCount;
        }

        public void ResetRetryTime() 
        {
            retryTimeCount = 0f;
        }
    }
}


