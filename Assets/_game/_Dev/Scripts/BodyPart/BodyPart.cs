using System;
using _game._Dev.Scripts.Controllers;
using _game._Dev.Scripts.Item;
using Sirenix.OdinInspector;
using UnityEngine;

using item = _game._Dev.Scripts.Item.Item;

namespace _game._Dev.Scripts.BodyPart
{
    [Serializable]
    public class BodyPart
    {
        [SerializeField, ReadOnly] private BodyPartSo m_bodyPartSo;
        [SerializeField, ReadOnly] private ItemSo m_currentItemSo;
        
        public BodyPartType BodyPartType;
        public int ItemIndex = 0;
        
        public GameObject CurrentItem;

        public BodyPart(BodyPartSo so)
        {
            m_bodyPartSo = so;
            BodyPartType = so.BodyPartType;
            ItemIndex = 0;
        }

        public item EquipNextItem(bool toNext = true)
        {
            if (ItemIndex >= m_bodyPartSo.UsableItems.Count || ItemIndex < 0)
                ItemIndex = 0;
            
            m_currentItemSo = m_bodyPartSo.UsableItems[ItemIndex];
            CustomizationController.instance.RemoveNeededItems(m_currentItemSo);

            if (toNext)
                ItemIndex++;
            else
                ItemIndex--;
            
            return m_currentItemSo.Prefab;
        }
    }
}