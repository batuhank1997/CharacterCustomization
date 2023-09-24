using System;
using System.Collections.Generic;
using _game._Dev.Scripts.Item;
using UnityEngine;
using item = _game._Dev.Scripts.Item.Item;
using bodyPart = _game._Dev.Scripts.BodyPart.BodyPart;
using CharacterController = _game._Dev.Scripts.Character.CharacterController;

namespace _game._Dev.Scripts.Controllers
{
    public class CustomizationController : MonoBehaviour
    {
        [SerializeField] private List<bodyPart> m_bodyParts;

        public List<bodyPart> BodyParts => m_bodyParts;

        public static CustomizationController instance;

        private void Awake()
        {
            instance = this;
        }

        public void ChangeItem(BodyPartType type, bool toNext = true)
        {
            var equipNakedPart = GetBodyPart(BodyPartType.FullBody).CurrentItem != null 
                && (type == BodyPartType.UpperBody || type == BodyPartType.LowerBody);
            
            if (equipNakedPart)
            {
                var opposite = 
                    GetBodyPart(type == BodyPartType.UpperBody
                        ? BodyPartType.LowerBody 
                        : BodyPartType.UpperBody).EquipNextItem(toNext);
                
                EquipItem(opposite);
            }
            
            var item = GetBodyPart(type).EquipNextItem(toNext);
            EquipItem(item);
        }

        private void EquipItem(item item)
        {
            var part = GetBodyPart(item.Type);
            var equippedItem = Instantiate(item, Vector3.zero, Quaternion.Euler(new Vector3(0, 180, 0)));

            part.CurrentItem = equippedItem.gameObject;
            
            equippedItem.SetItem(equippedItem is AccessoryItem ? GetParentBone(equippedItem.Type) : transform);
        }

        private bodyPart GetBodyPart(BodyPartType type)
        {
            return m_bodyParts.Find(x => x.BodyPartType == type);
        }

        private Transform GetParentBone(BodyPartType type)
        {
            return CharacterController.instance.BoneParents.Find(bone => bone.Type == type).Parent;
        }

        public void RemoveNeededItems(ItemSo itemToEquip)
        {
            foreach (var removal in itemToEquip.Removals)
            {
                var item = GetBodyPart(removal).CurrentItem;
                
                if (item)
                    Destroy(item);
            }
        }
    }
    
    [Serializable]
    public class BoneParent
    {
        public Transform Parent;
        public BodyPartType Type;
    }
}