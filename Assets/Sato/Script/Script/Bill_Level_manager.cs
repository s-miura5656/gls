using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectLevelData
{
    [SerializeField] public string hedderName = "";
    // 各レベルのBOXコライダーを取得
    [SerializeField] public List<BoxCollider> bill_collider = null;
}

public class Bill_Level_manager : MonoBehaviour
{
    private static readonly int BillLevel = 6;

    [SerializeField] private ObjectLevelData[] objectLevelData = new ObjectLevelData[BillLevel];
    [SerializeField] private int[] billDestroyLevel = { 2, 4, 6, 8, 10, 12 };

    /// <summary>
    /// ビルが破壊可能かどうか
    /// </summary>
    public void BillPossible(int player_level) 
    {
        for (int i = 0; i < objectLevelData.Length; i++)
        {
            if (player_level < billDestroyLevel[i]) continue;

            var colliders = objectLevelData[i].bill_collider;

            foreach (var collider in colliders)
            {
                if (collider.isTrigger != true)
                {
                    collider.isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 壊れるもののボックスコライダーを取得
    /// </summary>
    private void Reset()
    {    
        var childs = GetComponentsInChildren<Transform>();

        for (int i = 0; i < objectLevelData.Length; i++)
        {
            foreach(var child in childs)
            {
                if (child.gameObject.tag == $"Bill_Level_{i}")
                {
                    objectLevelData[i].bill_collider.Add(child.GetComponent<BoxCollider>());
                }
            }
            objectLevelData[i].hedderName = $"Level_{i + 1}";
        }
    }
}
