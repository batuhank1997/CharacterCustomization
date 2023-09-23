using System;
using _game._Dev.Scripts.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _game._Dev.Scripts.UI
{
    public class CustomizePartView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private Button m_buttonL;
        [SerializeField] private Button m_buttonR;
        
        public void Init(BodyPartType type, Action left, Action right)
        {
            m_buttonL.onClick.AddListener(() => left?.Invoke());
            m_buttonR.onClick.AddListener(() => right?.Invoke());
            
            m_text.text = type.ToString();
        }
    }
}
