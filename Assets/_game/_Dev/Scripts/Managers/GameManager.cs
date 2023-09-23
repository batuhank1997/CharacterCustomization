using _game._Dev.Scripts.Controllers;
using UnityEngine;
using CharacterController = _game._Dev.Scripts.Character.CharacterController;

namespace _game._Dev.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            CharacterController.instance.Init();
            UIController.instance.Init();
        }
    }
}