using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class EffectBase
    {
        private ParticleSystem particleSystem = null;
        

        public void Initilize(GameObject effectObject)
        {
            particleSystem = effectObject.GetComponent<ParticleSystem>();
        }

        public void EffectMove(Transform effectTransform, Transform targetTransform)
        {
            Vector3 movePos = targetTransform.position;

            movePos.y = targetTransform.localScale.y / 2f;

            effectTransform.position = movePos;
        }

       
    }
}



