using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash 
{
    public class NewCameraManager : MonoBehaviour
    {
        [Header("プレイヤーのScriptableObject")]
        [SerializeField] private NewPlayerParametor playerParametor = null;
        [Header("カメラで見る対象を入れてください")]
        [SerializeField] private Transform targetTransform          = null;
        [Header("メインカメラを入れてください")]
        [SerializeField] private Transform cameraTransform          = null;
        [Header("カメラ移動の補完時間")]
        [SerializeField] private float cameraMoveTime               = 1.0f;
        [Header("カメラの初期位置")]
        [SerializeField] private Vector3 cameraMoveOffset           = Vector3.zero;
        [Header("対象とカメラの距離の補完時間")]
        [SerializeField] private float changeDistanceTime           = 2f;

        private CameraBase cameraBase = new CameraBase();

        public void Initialize()
        {
            cameraBase.Initialize(playerParametor.CameraDistance[PlayerData.Instance.GetLevel]);
        }

        public void FixedManagedUpdate()
        {
            cameraTransform.rotation = 
                cameraBase.LookTarget(targetTransform.position, cameraTransform.position);

            cameraTransform.position = 
                cameraBase.MoveCamera(targetTransform.position, cameraMoveOffset, cameraMoveTime);

            cameraBase.ChangeDistance(playerParametor, changeDistanceTime);

            cameraTransform.position =
                cameraBase.SetDistancePosition(targetTransform.position, cameraTransform.position);
        }
    }
}
