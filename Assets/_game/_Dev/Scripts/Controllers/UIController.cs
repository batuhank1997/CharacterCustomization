using _game._Dev.Scripts.UI;
using UnityEngine;

namespace _game._Dev.Scripts.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Transform m_customizationMenuLayoutParent;
        [SerializeField] private CustomizePartView m_viewPrefab;
        
        public static UIController instance;

        private void Awake()
        {
            instance = this;
        }

        public void Init()
        {
            InitCustomizeMenu();
        }

        private void InitCustomizeMenu()
        {
            foreach (var part in CustomizationController.instance.BodyParts)
            {
                var view = Instantiate(m_viewPrefab, m_customizationMenuLayoutParent);

                view.Init(part.BodyPartType,
                    () =>
                    {
                        CustomizationController.instance.ChangeItem(part.BodyPartType, false);
                    }, 
                    () =>
                    {
                        CustomizationController.instance.ChangeItem(part.BodyPartType, true);
                    });
            }
        }
    }
}
