using UnityEngine;
using UnityEngine.UI;

namespace PicolaApp.KataKoto
{
    public class CanvasScalerController : MonoBehaviour
    {
        private float width = 1080;
        private float height = 1920;

        private void Start()
        {
            var scaler = GetComponent<CanvasScaler>();

            // 想定のアスペクト比と比べて画面比率が縦長だったら横合わせにする
            if (Screen.height / Screen.width > height / width)
            {
                scaler.matchWidthOrHeight = 0;
            }
        }
    }
}
