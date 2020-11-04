using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;
using UnityEngine.Assertions.Must;

namespace Human.BuildingCrash
{
    public class NewPlayerManager : MonoBehaviour
    {
        [SerializeField] private NewPlayerParametor playerParametor = null;
        [SerializeField] private GameObject player                  = null;
        [SerializeField] private GameObject smokeEffect             = null;
        [SerializeField] private float stopSpeed                    = 10f;
        [SerializeField] private float powor                        = 10f;

        private Rigidbody rigidBody           = null;
        private SphereCollider sphereCollider = null;

        private PlayerBase playerBase = new PlayerBase();
        private EffectBase effectBase = new EffectBase();

        public void Initialize()
        {
            PlayerData.Instance.Initialize(playerParametor);
            rigidBody = player.GetComponent<Rigidbody>();
            sphereCollider = player.GetComponent<SphereCollider>();
            effectBase.Initilize(smokeEffect);
        }

        public void ManagedUpdate()
        {
            playerBase.PullMove(rigidBody, true, powor);
            effectBase.EffectMove(smokeEffect.transform, player.transform);
            playerBase.FowardRotation(rigidBody, this.transform, sphereCollider);
            playerBase.MoveStop(rigidBody, stopSpeed);
            playerBase.LevelUp(playerParametor.MaxLevel, 
                               playerParametor.ExperienceTable, 
                               playerParametor.AttackPoworTable);
        }
    }

    public class PlayerData
    {
        public readonly static PlayerData Instance = new PlayerData();

        private int playerLevel           = 0;
        private int playerTotalExperience = 0;
        private int playerAttackPowor     = 0;

        //! 初期化
        public void Initialize(NewPlayerParametor playerparametor)
        {
            playerLevel           = 0;
            playerTotalExperience = 0;
            playerAttackPowor     = playerparametor.AttackPoworTable[playerLevel];

#if UNITY_EDITOR
            Debug.Log("プレイヤーのレベル " + playerLevel);
            Debug.Log("プレイヤーの経験値 " + playerTotalExperience);
            Debug.Log("プレイヤーの攻撃力 " + playerAttackPowor);
#endif
        }

        //! レベル
        public int GetLevel { get { return playerLevel; } }
        public void SetLevel(int player_level) { playerLevel = player_level; }

        //! 攻撃力
        public int GetAttackPowor { get { return playerAttackPowor; } }
        public void SetAttackPowor(int player_atk) { playerAttackPowor = player_atk; }

        //! プレイヤーの取得経験値
        public int GetExperience { get { return playerTotalExperience; } }
        public void SetExperience(int experience) { playerTotalExperience += experience; }
    }
}


