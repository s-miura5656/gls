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

        [Header("レベル毎に取得できる経験値")]
        [SerializeField] private int[] experience = new int[destroyObjMaxLevel];

        public int[] Experience { get { return experience; } }

        [Header("ヒットポイント")]
        [SerializeField] private int[] hitPoint = new int[destroyObjMaxLevel];

    }
}

