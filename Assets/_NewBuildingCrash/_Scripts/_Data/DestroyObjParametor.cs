using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    [CreateAssetMenu(menuName = "Create DestroyObjParametor", fileName = "DestroyObjParametor")]
    public class DestroyObjParametor : ScriptableObject
    {
        [SerializeField] private const int destroyObjMaxLevel = 6;
        private const int expMaxSize = destroyObjMaxLevel * 2;

        #region レベル毎の取得できる経験値
        [Header("レベル毎の取得できる経験値")]
        [SerializeField] private int[] experience = new int[destroyObjMaxLevel];
        public int[] Experience { get { return experience; } }
        #endregion

        #region ビルのヒットポイント
        [Header("ヒットポイント")]
        [SerializeField] private int[] hitPoint = new int[destroyObjMaxLevel];
        public int[] HitPoint { get { return hitPoint; } }
        #endregion
    }
}

