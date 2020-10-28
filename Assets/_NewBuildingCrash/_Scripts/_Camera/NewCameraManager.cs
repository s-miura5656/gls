using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash 
{
    public class NewCameraManager : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform    = null;
        [SerializeField] private Transform cameraTransform    = null;
        [SerializeField] private float cameraSpeed            = 1.0f;
        [SerializeField] private Vector3 cameraMoveOffset     = Vector3.zero;

        private CameraBase cameraBase = new CameraBase();
        Vector3 oldPos = Vector3.zero;

        public void Initialize()
        {
            oldPos = cameraTransform.position;
        }

        public void FixedManagedUpdate()
        {
            Camera.main.transform.LookAt(playerTransform);

            cameraTransform.position = 
                cameraBase.MoveCamera(playerTransform.position, cameraMoveOffset, cameraSpeed);
        }
    }
}
