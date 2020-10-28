using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;

namespace Human.BuildingCrash
{
    public class NewPlayerManager : MonoBehaviour
    {
        [SerializeField] private Parametor playerParam         = null;
        [SerializeField] private GameObject player             = null;
        [SerializeField] private GameObject smokeEffect        = null;
        [SerializeField] private float stopSpeed               = 10f;
        [SerializeField] private float powor                   = 10f;

        private Rigidbody rigidBody           = null;
        private SphereCollider sphereCollider = null;

        private PlayerBase playerBase = new PlayerBase();
        private EffectBase effectBase = new EffectBase();

        public void Initialize()
        {
            rigidBody = player.GetComponent<Rigidbody>();
            sphereCollider = player.GetComponent<SphereCollider>();
            effectBase.Initilize(smokeEffect);
        }

        public void ManagedUpdate()
        {
            playerBase.PullMove(rigidBody, true, 10f);
            effectBase.EffectMove(smokeEffect.transform, player.transform);
            playerBase.FowardRotation(rigidBody, this.transform, sphereCollider);
            playerBase.MoveStop(rigidBody, stopSpeed);
        }
    }
}


