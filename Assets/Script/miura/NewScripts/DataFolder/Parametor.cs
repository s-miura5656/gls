using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    [CreateAssetMenu(menuName = "TeruTeru/Create PlayerParametor", fileName = "PlayerParametor")]
    public class Parametor : ScriptableObject
    {
        [Header("プレイヤーのレベルの最大値")] [SerializeField] private int player_level_max = 0;
        [Header("プレイヤーのレベル毎の経験値")] [SerializeField] private int[] player_level_up_exp;
        [Header("プレイヤーのレベル毎のサイズ")] [SerializeField] private float[] player_scale;
        [Header("プレイヤーのレベル毎に力を加える力")] [SerializeField] private float[] player_powor;
        [Header("プレイヤーのレベル毎のカメラの離れていく距離")] [SerializeField] private Vector3[] player_level_up_camera;
        [Header("引っ張り距離の固定")] [SerializeField] private float rangeFixed = 200f;
        [Header("プレイヤーについているスモークの大きさ")] [SerializeField] private Vector3 smoke_size = Vector3.one;
        [Header("スキン毎の速度のパラメーター")] [SerializeField] private float[] player_skin_speed;
        [Header("引き直しのアニメが流れるようになる速度")] [SerializeField] private float animation_start;

        public int PlayerLevelMax
        {
            get { return player_level_max; }
        }

        public int[] PlayerLevelUpExp
        {
            get { return player_level_up_exp; }
        }

        public float[] PlayerScale
        {
            get { return player_scale; }
        }

        public float[] PlayerPowor
        {
            get { return player_powor; }
        }

        public float RangeFixed
        {
            get { return rangeFixed; }
        }

        public Vector3 SmokeSize
        {
            get { return smoke_size; }
        }

        public Vector3[] PlayerLevelUpCamera
        {
            get { return player_level_up_camera; }
        }

        public float[] PlayerSkinPramSpeed
        {
            get { return player_skin_speed; }
        }

        public float AnimationStart
        {
            get { return animation_start; }
        }
    }

}

