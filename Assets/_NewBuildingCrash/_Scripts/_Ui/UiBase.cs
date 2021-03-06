﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Human.BuildingCrash
{
    public class UiBase
    {
        private SpriteRenderer spriteRenderer = null;
        private Vector3 baseMousePos = Vector3.zero;
        private float skinObjectScale = 0;
        private int oldLevel = 0;

        private const float pullDistanceMin = 1f;
        private const float pullDistanceMax = 3f;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="arrowSpriteObject">矢印のオブジェクト</param>
        /// <param name="skinScale">スキンのスケール</param>
        public void Initilize(GameObject arrowSpriteObject, float skinScale)
        {
            spriteRenderer = arrowSpriteObject.GetComponent<SpriteRenderer>();
            skinObjectScale = skinScale;
        }

        #region 矢印関係
        /// <summary>
        /// 引っ張り時の矢印動き
        /// </summary>
        /// <param name="player"></param>
        public void PullArrowController(Transform player)
        {
            var arrowObject = spriteRenderer.gameObject;

            if (Input.GetMouseButtonDown(0))
            {
                baseMousePos = Input.mousePosition;

                Vector3 rendererPos = spriteRenderer.gameObject.transform.right.normalized;

                rendererPos.y = 0;

                rendererPos *= player.transform.localScale.y;

                arrowObject.transform.position = player.transform.position + rendererPos;

                spriteRenderer.enabled = true;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;

                var distance = (baseMousePos - mousePos).magnitude / 20f;

                distance = Mathf.Clamp(distance, pullDistanceMin, pullDistanceMax);

                //! 矢印の向き(回転)の設定
                float angle = Mathf.Atan2(baseMousePos.y - mousePos.y, baseMousePos.x - mousePos.x);
                arrowObject.transform.rotation = Quaternion.Euler(new Vector3(90f, -(angle * Mathf.Rad2Deg), 0));

                //! 表示位置の設定
                Vector3 rendererPos = spriteRenderer.gameObject.transform.right.normalized;
                rendererPos.y = 0;
                rendererPos *= player.transform.localScale.y * skinObjectScale;
                arrowObject.transform.position = player.transform.position + rendererPos;

                //! スケールの設定
                Vector3 arrowScale = Vector3.one * distance;
                arrowScale *= player.localScale.x;
                arrowScale.z = arrowObject.transform.localScale.z;
                arrowObject.transform.localScale = arrowScale;
            }

            if (Input.GetMouseButtonUp(0))
            {
                spriteRenderer.enabled = false;
            }
        }
        #endregion

        #region 経験値ゲージ
        /// <summary>
        /// 経験値ゲージの移動
        /// </summary>
        /// <param name="target"></param>
        /// <param name="gage"></param>
        public void ExperienceGageMove(Transform target, Transform gage)
        {
            var pos = target.position;

            gage.position = pos;
        }

        /// <summary>
        /// 経験値ゲージのサイズ調整
        /// </summary>
        /// <param name="gage"></param>
        /// <param name="scale"></param>
        /// <param name="time"></param>
        public void ExperienceGageScaleControl(Transform gage ,float scale, float time) 
        {
            gage.DOScale(Vector3.one * scale, time);
        }

        //public float ExperienceGageFillAmountControl(NewPlayerParametor playerParametor) 
        //{
        //    var data = PlayerData.Instance;

        //    int needExperiencePoints = 0;

        //    if (oldLevel != data.GetLevel)
        //    {
        //        needExperiencePoints = playerParametor.ExperienceTable[data.GetLevel] - playerParametor.ExperienceTable[oldLevel];
        //    }



        //    return 
        //}
        #endregion
    }
}
