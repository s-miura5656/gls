using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class PlayerBase
    {
        /// <summary>
        /// 引っ張り操作
        /// </summary>
        /// <param name="rb">動かしたいオブジェクトのリジッドボディ</param>
        /// <param name="gameStartFlag">動かせるようにするためのフラグ</param>
        /// <param name="powor">移動させるための力</param>
        public void PullMove(Rigidbody rb, bool gameStartFlag, float powor)
        {
            var startPos        = Vector3.zero;
            var endPos          = Vector3.zero;
            var moveDir         = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity        = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;

                moveDir = -(startPos - endPos).normalized;

                moveDir = new Vector3(moveDir.x, 0f, moveDir.y);

                //! フラグ true の時のみ動ける
                if (gameStartFlag)
                    rb.AddForce(moveDir * powor, ForceMode.Impulse);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="rb">止めたいオブジェクトのリジッドボディ</param>
        /// <param name="stopSpeed">停止させる速度</param>
        public void MoveStop(Rigidbody rb, float stopSpeed)
        {
            if (rb.velocity.magnitude <= stopSpeed)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}

