using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;
using UnityEngine.Assertions.Must;

namespace Human.BuildingCrash
{
    public class NewPlayerManager : MonoBehaviour
    {
        [Header("プレイヤーのScriptableObject")]
        [SerializeField] private NewPlayerParametor playerParametor = null;
        [Header("プレイヤーのGameObject")]
        [SerializeField] private GameObject player                  = null;
        [Header("移動した時の土煙のエフェクトのGameobject")]
        [SerializeField] private GameObject smokeEffect             = null;
        [Header("移動停止させる速度")]
        [SerializeField] private float stopSpeed                    = 10f;
        [Header("引っ張って離したときにどのくらいの力をかけるか")]
        [SerializeField] private float powor                        = 10f;
        [Header("レベルアップ時のスケールアップのアニメーションの補完時間")]
        [SerializeField] private float scaleUpTime                  = 2f;

        private Rigidbody rigidBody           = null;
        private SphereCollider sphereCollider = null;

        private PlayerBase playerBase = new PlayerBase();
        private EffectBase effectBase = new EffectBase();

        public void Initialize()
        {
            var data = PlayerData.Instance;

            data.Initialize(playerParametor, player.transform);
            effectBase.Initilize(smokeEffect);

            player.transform.localScale = Vector3.one * playerParametor.SizeTable[data.GetLevel];
            rigidBody = player.GetComponent<Rigidbody>();
            sphereCollider = player.GetComponent<SphereCollider>();
        }

        public void ManagedUpdate()
        {
            playerBase.PullMove(rigidBody, true, powor);

            playerBase.FowardRotation(rigidBody, this.transform, sphereCollider);

            playerBase.MoveStop(rigidBody, stopSpeed);

            effectBase.EffectMove(smokeEffect.transform, player.transform, rigidBody, stopSpeed);

            playerBase.LevelUp(playerParametor, player.transform, scaleUpTime);
        }
    }

    public class PlayerData
    {
        public readonly static PlayerData Instance = new PlayerData();

        private Transform transform = null;
        private int level           = 0;
        private int totalExperience = 0;
        private int attackPowor     = 0;

        //! 初期化
        public void Initialize(NewPlayerParametor playerparametor, Transform player_transform)
        {
            level = 0;
            totalExperience = 0;
            attackPowor = playerparametor.AttackPoworTable[level];
            transform = player_transform;
#if UNITY_EDITOR
            Debug.Log("プレイヤーのレベル " + level);
            Debug.Log("プレイヤーの経験値 " + totalExperience);
            Debug.Log("プレイヤーの攻撃力 " + attackPowor);
#endif
        }

        //! レベル
        public int GetLevel { get { return level; } }
        public void SetLevel(int player_level) { level = player_level; }

        //! 攻撃力
        public int GetAttackPowor { get { return attackPowor; } }
        public void SetAttackPowor(int player_atk) { attackPowor = player_atk; }

        //! プレイヤーの取得経験値
        public int GetExperience { get { return totalExperience; } }
        public void SetExperience(int player_experience) { totalExperience += player_experience; }

        //! プレイヤーのTransform
        public Transform GetTransform { get { return transform; } }
        public void SetTransform(Transform player_transform) { transform = player_transform; }
    }
}


