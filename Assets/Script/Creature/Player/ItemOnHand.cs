using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemOnHand : MonoBehaviour
{
    public static ItemOnHand Instance;

    public Item item;//要扔的物体的Item
    public GameObject itemPrefab;//要扔的物体的预制体

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Update()
    {
        item = CurrentHoldItem();

        SearchForPrefab(item);
    }

    //给投掷返回一个可以扔的对象Item
    public Item CurrentHoldItem()
    {
        if (InventoryManager.instance.ItemColumn.itemlist.Count == 0)
            return null;
        //这里是从列表第一个物体开始使用，因为找不到切换物品的功能
        else
        {
            //此时拿着第一个物体
            return InventoryManager.instance.ItemColumn.itemlist[0];
        }
    }
    //根据Inventory列表返回的第一个Item来找对应的预制体
    private void SearchForPrefab(Item item)
    {
        string[] prefabs = AssetDatabase.FindAssets("t:Prefab");

        foreach (string pf in prefabs)
        {
            string path = AssetDatabase.GUIDToAssetPath(pf);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            if (prefab != null)
            {
                if (prefab.GetComponent<InventoryManager>() != null)
                {
                    itemPrefab = prefab.GetComponent<ItemOnWorld>().thisItem == item ? prefab : null;
                }
            }
        }
    }
}
