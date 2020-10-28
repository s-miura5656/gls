using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class CameraBase
    {
        private Vector3 oldPos = Vector3.zero;

        /// <summary>
        /// カメラの追従
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="offSet"></param>
        /// <param name="cameraSpeed"></param>
        /// <returns></returns>
        public Vector3 MoveCamera(Vector3 targetPos, Vector3 offSet, float cameraSpeed)
        {
            // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
            Vector3 movePos = targetPos + offSet;

            // Lerp補完で滑らか移動
            movePos = Vector3.Lerp(oldPos, movePos, cameraSpeed);

            oldPos = movePos;

            return movePos;
        }

        /// <summary>
        /// 対象を注視する
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="cameraPos"></param>
        /// <returns></returns>
        public Quaternion LookTarget(Vector3 targetPos, Vector3 cameraPos) 
        {
            var direction = targetPos - cameraPos;

            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            lookRotation.eulerAngles = new Vector3(lookRotation.eulerAngles.x, 0, 0);

            return lookRotation;
        }

        /// <summary>
        /// 距離からカメラのポジションを取得
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="cameraPos"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public Vector3 SetDistancePosition(Vector3 targetPos, Vector3 cameraPos, float distance) 
        {
            var dif = cameraPos - targetPos;

            float rad = Mathf.Atan2(dif.y, dif.z);

            float y = (float)Math.Sin(rad) * distance;
            float z = (float)Math.Cos(rad) * distance;

            var answer = rad * Mathf.Rad2Deg;

            return targetPos + new Vector3(0, y, z);
        }
    }
}

