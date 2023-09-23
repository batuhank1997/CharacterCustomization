using UnityEngine;

namespace _game._Dev.Scripts.Item
{
    public class AccessoryItem : Item
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }
    }
}