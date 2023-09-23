using System.Collections.Generic;
using System.Linq;
using _game._Dev.Scripts.BodyPart;
using _game._Dev.Scripts.Controllers;
using _game._Dev.Scripts.Item;
using UnityEngine;

using item = _game._Dev.Scripts.Item.Item;
using bodyPart = _game._Dev.Scripts.BodyPart.BodyPart;

namespace _game._Dev.Scripts.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;

        public Animator Animator => m_animator;

        [SerializeField] private List<BodyPartSo> m_bodyParts;
        [SerializeField] private List<BoneParent> m_boneParents;

        public List<BoneParent> BoneParents => m_boneParents;

        public static CharacterController instance;

        private void Awake()
        {
            instance = this;
        }

        public void Init()
        {
            InitBodyParts();
            SetDefaultItems();
        }
        
        private void InitBodyParts()
        {
            foreach (var bodyPart in m_bodyParts)
            {
                CustomizationController.instance.BodyParts.Add(new bodyPart(bodyPart));
            }
        }

        private void SetDefaultItems()
        {
            foreach (var bodyPart in m_bodyParts.Where(bodyPart => bodyPart.BodyPartType != BodyPartType.FullBody))
            {
                CustomizationController.instance.ChangeItem(bodyPart.BodyPartType);
            }
        }
    }
}
