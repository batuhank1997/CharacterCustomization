using UnityEngine;

namespace _game._Dev.Scripts.Item
{
    public class AccessoryItem : Item
    {
        public override void SetItem(Transform parent)
        {
            base.SetItem(parent);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}