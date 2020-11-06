using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class EffectBase
    {
        private ParticleSystem particleSystem = null;
        
        public void Initialize(GameObject effectObject)
        {
            particleSystem = effectObject.GetComponent<ParticleSystem>();
        }

        /// <summary>
        /// 移動時の土煙の再生と停止とプレイヤーに追従
        /// </summary>
        /// <param name="effectTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="rigidbody"></param>
        /// <param name="stopSpeed"></param>
        public void EffectMove(Transform effectTransform, Transform targetTransform, 
                               Rigidbody rigidbody, float stopSpeed)
        {
            if (rigidbody.velocity.magnitude < stopSpeed)
                particleSystem.Stop();
            else
                particleSystem.Play();

            Vector3 movePos = targetTransform.position;

            movePos.y = targetTransform.localScale.y / 2f;

            effectTransform.position = movePos;
        }
    }
}



