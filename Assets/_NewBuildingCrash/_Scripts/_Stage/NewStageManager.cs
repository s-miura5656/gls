using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;

namespace Human.BuildingCrash
{
    public class NewStageManager : MonoBehaviour
    {
        [SerializeField] private NewDestroyObj[] newDestroyObjs = { null };

        public void Initialize()
        {
            
        }

        public void ManagedUpdate()
        {
            //var playerLevel = //! プレイヤーのレベル

            foreach (var billObjScript in newDestroyObjs)
            {
                billObjScript.ManagedUpdate();
            }
        }

        private void Reset()
        {
            newDestroyObjs = GetComponentsInChildren<NewDestroyObj>();

            foreach (var billObjScript in newDestroyObjs)
            {
                billObjScript.Initilize();
            }
        }
    }
}

