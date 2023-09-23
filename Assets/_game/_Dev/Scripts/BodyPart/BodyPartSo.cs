using System.Collections.Generic;
using _game._Dev.Scripts.Item;
using UnityEngine;

namespace _game._Dev.Scripts.BodyPart
{
    [CreateAssetMenu(fileName = "BodyPartSo", menuName = "ScriptableObjects/BodyPart", order = 0)]
    public class BodyPartSo : ScriptableObject
    {
        public BodyPartType BodyPartType;
        public List<ItemSo> UsableItems;
    }
}