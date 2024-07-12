using System;
using UnityEngine;

namespace Script
{
    public class GameMain : MonoBehaviour
    {
        private void Awake()
        {
            ConfigManager.Instance.Awake();
            InputManager.Instance.Awake();
            GridManager.Instance.Awake();
            ItemManager.Instance.Awake();
            
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