using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    [CreateAssetMenu(menuName = "Create NewPlayerParametor", fileName = "NewPlayerParametor")]
    public class NewPlayerParametor : ScriptableObject
    {
        [Header("最大レベル")]
        [SerializeField] private int maxLevel = 10;

        public int MaxLevel { get { return maxLevel; } }


        [Header("経験値テーブル")]
        [SerializeField] private int[] experienceTable = { 0 };

        public int[] ExperienceTable { get { return experienceTable; } }


        [Header("攻撃力テーブル")]
        [SerializeField] private int[] attackPoworTable = { 0 };

        public int[] AttackPoworTable { get { return attackPoworTable; } }
    }
}
