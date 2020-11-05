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
        [Header("引っ張ってる時の矢印のGameObject")]
        [SerializeField] private GameObject arrowSprite             = null;
        [Header("移動停止させる速度")]
        [SerializeField] private float stopSpeed                    = 10f;
        [Header("引っ張って離したときにどのくらいの力をかけるか")]
        [SerializeField] private float powor                        = 10f;
        [Header("レベルアップ時のスケールアップのアニメーションの補完時間")]
        [SerializeField] private float scaleUpTime                  = 2f;

        private Rigidbody rigidBody           = null;
        private SphereCollider sphereCollider = null;
        private float skinScale               = 5f;

        private PlayerBase playerBase = new PlayerBase();
        private EffectBase effectBase = new EffectBase();
        private UiBase uiBase         = new UiBase();

        public void Initialize()
        {
            var data = PlayerData.Instance;

            data.Initialize(playerParametor);
            uiBase.Initilize(arrowSprite, skinScale);
            effectBase.Initilize(smokeEffect);

            player.transform.localScale = Vector3.one * playerParametor.SizeTable[data.GetLevel];
            rigidBody = player.GetComponent<Rigidbody>();
            sphereCollider = player.GetComponent<SphereCollider>();
        }

        public void ManagedUpdate()
        {
            playerBase.PullMove(rigidBody, true, powor);
            uiBase.PullArrowController(player);
            effectBase.EffectMove(smokeEffect.transform, player.transform);
            playerBase.FowardRotation(rigidBody, this.transform, sphereCollider);
            playerBase.MoveStop(rigidBody, stopSpeed);
            playerBase.LevelUp(playerParametor, player.transform, scaleUpTime);
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


