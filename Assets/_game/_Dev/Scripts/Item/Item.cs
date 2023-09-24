using UnityEngine;

namespace _game._Dev.Scripts.Item
{
    public abstract class Item : MonoBehaviour
    {
        public BodyPartType Type;
        
        public virtual void SetItem(Transform parent)
        {
            transform.SetParent(parent);
        }
    }
}