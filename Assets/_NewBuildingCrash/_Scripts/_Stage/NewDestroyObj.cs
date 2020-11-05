using Human.BuildingCrash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Human.BuildingCrash
{
    public class NewDestroyObj : MonoBehaviour
    {
        [SerializeField] private DestroyObjParametor destroyObjParametor = null;

        private const int getStringNum = 6;

        private int billLevel = 0;

        public void Initilize()
        {
            billLevel = int.Parse(gameObject.tag.Substring(getStringNum));
        }

        public void ManagedUpdate()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;

            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag != "Player")
                return;

            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            //! 倒されたらビルのレベルに応じて経験値を送る
            PlayerData.Instance.SetExperience(destroyObjParametor.Experience[billLevel]);
#if UNITY_EDITOR
            Debug.Log("現在の経験値 " + PlayerData.Instance.GetExperience);
#endif
        }
    }
}

