using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    [CreateAssetMenu(menuName = "Create NewPlayerParametor", fileName = "NewPlayerParametor")]
    public class NewPlayerParametor : ScriptableObject
    {
        #region 最大レベル
        [Header("最大レベル")]
        [SerializeField] private int maxLevel = 10;
        public int MaxLevel { get { return maxLevel; } }
        #endregion

        #region 経験値テーブル
        [Header("経験値テーブル")]
        [SerializeField] private int[] experienceTable = { 0 };
        public int[] ExperienceTable { get { return experienceTable; } }
        #endregion

        #region 攻撃力テーブル
        [Header("攻撃力テーブル")]
        [SerializeField] private int[] attackPoworTable = { 0 };
        public int[] AttackPoworTable { get { return attackPoworTable; } }
        #endregion

        #region レベル毎のサイズ
        [Header("レベル毎のサイズ")]
        [SerializeField] private float[] sizeTable = { 0 };
        public float[] SizeTable { get { return sizeTable; } }
        #endregion

        #region レベル毎のカメラの距離
        [Header("レベル毎のカメラの距離")]
        [SerializeField] private float[] cameraDistance = { 0 };
        public float[] CameraDistance { get { return cameraDistance; } }
        #endregion

        #region レベル毎の経験値ゲージのサイズ
        [Header("レベル毎の経験値ゲージのサイズ")]
        [SerializeField] private float[] experienceGageScale = { 0 };
        public float[] ExperienceGageScale { get { return experienceGageScale; } }
        #endregion
    }
}
