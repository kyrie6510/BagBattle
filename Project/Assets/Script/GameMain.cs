using System;
using UnityEngine;

namespace Script
{
    public class GameMain : MonoBehaviour
    {
        private void Awake()
        {
            ItemManager.Instance.Awake();
            InputManager.Instance.Awake();
            GridManager.Instance.Awake();
            ConfigManager.Instance.Awake();
            
        }

        private void Update()
        {
            ConfigManager.Instance.Update();
            InputManager.Instance.Update();
            GridManager.Instance.Update();
            ItemManager.Instance.Update();
        }

        
        
    }
}