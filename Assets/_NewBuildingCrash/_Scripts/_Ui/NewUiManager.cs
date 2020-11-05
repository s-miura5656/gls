using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.BuildingCrash;

namespace Human.BuildingCrash
{
    public class NewUiManager : MonoBehaviour
    {
        [Header("プレイヤーのScriptableObject")]
        [SerializeField] private NewPlayerParametor playerParametor = null;
        [Header("プレイヤーのUI用Canvas")]
        [SerializeField] private Canvas playerCanvas                = null;
        [Header("引っ張ってる時の矢印のGameObject")]
        [SerializeField] private GameObject arrowSprite             = null;
        [Header("経験値ゲージのスケールアップのアニメーションの補完時間")]
        [SerializeField] private float scaleUpTime                  = 2f;

        private float skinScale = 5f;

        private UiBase uiBase = new UiBase();

        public void Initialize()
        {
            uiBase.Initilize(arrowSprite, skinScale);
        }

        public void ManagedUpdate()
        {
            
        }

        public void ManagedLateUpdate()
        {
            var data = PlayerData.Instance;

            uiBase.PullArrowController(data.GetTransform);

            uiBase.ExperienceGageMove(data.GetTransform, playerCanvas.transform);

            uiBase.ExperienceGageScaleControl(playerCanvas.transform, 
                                              playerParametor.ExperienceGageScale[data.GetLevel], 
                                              scaleUpTime);
        }
    }
}
