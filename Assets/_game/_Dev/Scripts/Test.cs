using System.Collections;
using System.Collections.Generic;
using _game._Dev.Scripts.BodyPart;
using _game._Dev.Scripts.Item;
using Sirenix.OdinInspector;
using UnityEngine;

public class Test : MonoBehaviour
{
    public List<Item> items;
    public List<ItemSo> itemsSos;
    public List<BodyPartSo> BodyPartSos;

    [Button]
    public void Merge()
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemsSos[i].Prefab = items[i];
            itemsSos[i].BodyPartType = items[i].Type;
        }
    }

    [Button]
    public void SetBodyParts()
    {
        foreach (var part in BodyPartSos)
        {
            var items = itemsSos.FindAll(item => item.BodyPartType == part.BodyPartType);

            foreach (var item in items)
            {
                part.UsableItems.Add(item);
            }
        }
    }
}
