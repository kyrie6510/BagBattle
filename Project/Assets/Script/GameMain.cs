using System;
using Game;
using Script.Event;
using UnityEngine;

namespace Script
{
    public class GameMain : MonoBehaviour
    {
        private Simulation _simulation;
        private bool _isGameStared = false;
        private void Awake()
        {
            
            EventManager.Instance.AddListener<OnGamePlayEvent>(OnGamePlay);
            
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


            if (!_isGameStared)
            {
                return;
            }
            
            _simulation.Update();
        }
        
        
        private void OnGamePlay(OnGamePlayEvent e)
        {
            GameUser user = new GameUser()
            {
                Items = ItemManager.Instance.GetAllItemData(),
                ActorId =  1,
            };

            var otherData = ItemManager.Instance.GetOtherData();
            
            GameUser user2 = new GameUser()
            {
                Items = otherData,
                ActorId =  2,
            };
            
            //创建UI
            ItemManager.Instance.GenerateItemForOther(otherData);
            
            
            _simulation = new Simulation(new GameUser[] { user,user2 });
            _isGameStared = true;
        }

        
        
    }
}