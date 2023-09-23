using System.Collections.Generic;
using UnityEngine;

namespace _game._Dev.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemSo", menuName = "ScriptableObjects/Item", order = 0)]
    public class ItemSo : ScriptableObject
    {
        public Item Prefab;
        public BodyPartType BodyPartType;
        public List<BodyPartType> Removals;
    }
}