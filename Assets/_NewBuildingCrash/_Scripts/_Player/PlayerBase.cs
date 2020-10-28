using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class PlayerBase
    {
        private Vector3 mStartPos = Vector3.zero;
        private Vector3 mEndPos = Vector3.zero;

        /// <summary>
        /// 引っ張り操作
        /// </summary>
        /// <param name="rb">動かしたいオブジェクトのリジッドボディ</param>
        /// <param name="gameStartFlag">動かせるようにするためのフラグ</param>
        /// <param name="powor">移動させるための力</param>
        public void PullMove(Rigidbody rb, bool gameStartFlag, float powor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity        = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                mStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                mEndPos = Input.mousePosition;

                var mMoveDir = (mStartPos - mEndPos).normalized;

                mMoveDir = new Vector3(mMoveDir.x, 0f, mMoveDir.y);

                //! フラグ true の時のみ動ける
                if (gameStartFlag)
                    rb.AddForce(mMoveDir * powor, ForceMode.Impulse);
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
                rb.velocity        = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        /// <summary>
        /// 進行方向へ回転させる
        /// </summary>
        public void FowardRotation(Rigidbody rb, Transform transform, SphereCollider sphereCollider)
        {
            var translation = rb.velocity * Time.deltaTime;

            var distance = translation.magnitude;

            var scaleXYZ = transform.lossyScale;

            var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z);

            var angle = distance / (sphereCollider.radius * scale);

            var axis = Vector3.Cross(Vector3.up, translation).normalized;

            var deltaRotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis);

            rb.MoveRotation(deltaRotation * rb.rotation);
        }
    }
}

