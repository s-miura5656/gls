using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;

namespace Human.BuildingCrash
{
    public class NewPlayerManager : MonoBehaviour
    {
        [SerializeField] private Parametor playerParam = null;
        [SerializeField] private Rigidbody rigidBody = null;
        [SerializeField] private SphereCollider sphereCollider = null;
        [SerializeField] private float stopSpeed = 10f;
        [SerializeField] private float powor = 10f;

        private PlayerBase playerBase = new PlayerBase();

        public void Initialize()
        {

        }

        public void ManagedUpdate()
        {
            playerBase.PullMove(rigidBody, true, 10f);
            playerBase.FowardRotation(rigidBody, this.transform, sphereCollider);
            playerBase.MoveStop(rigidBody, stopSpeed);
        }
    }
}


