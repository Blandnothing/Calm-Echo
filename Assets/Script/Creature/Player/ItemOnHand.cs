using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemOnHand : MonoBehaviour
{
    public static ItemOnHand Instance;

    public Item item;//Ҫ�ӵ������Item
    public GameObject itemPrefab;//Ҫ�ӵ������Ԥ����

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

    //��Ͷ������һ�������ӵĶ���Item
    public Item CurrentHoldItem()
    {
        if (InventoryManager.instance.ItemColumn.itemlist.Count == 0)
            return null;
        //�����Ǵ��б��һ�����忪ʼʹ�ã���Ϊ�Ҳ����л���Ʒ�Ĺ���
        else
        {
            //��ʱ���ŵ�һ������
            return InventoryManager.instance.ItemColumn.itemlist[0];
        }
    }
    //����Inventory�б��صĵ�һ��Item���Ҷ�Ӧ��Ԥ����
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
