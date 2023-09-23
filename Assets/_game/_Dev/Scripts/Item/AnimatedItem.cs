using System;
using Sirenix.OdinInspector;
using UnityEngine;
using CharacterController = _game._Dev.Scripts.Character.CharacterController;

namespace _game._Dev.Scripts.Item
{
    public class AnimatedItem : Item
    {
        [SerializeField] private Animator m_animator;
 
        public Animator Animator => m_animator;
        
        public void SetAnimation()
        {
            if (m_animator == null) return;

            m_animator.Play("Dance", 0, CharacterController.instance.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
}