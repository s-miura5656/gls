using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class CameraBase
    {
        private Vector3 oldPos = Vector3.zero;

        /// <summary>
        /// カメラの移動
        /// </summary>
        public Vector3 MoveCamera(Vector3 playerPos, Vector3 offSet, float cameraSpeed)
        {
            // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
            Vector3 movePos = playerPos + offSet;

            // Lerp補完で滑らか移動
            movePos = Vector3.Lerp(oldPos, movePos, cameraSpeed);

            oldPos = movePos;

            return movePos;
        }

        
    }
}

