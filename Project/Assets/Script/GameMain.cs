using System;
using Game;

using UnityEngine;
using Time = UnityEngine.Time;

namespace Script
{
    public class GameMain : MonoBehaviour
    {
        private Simulation _simulation;
        private bool _isGameStared = false;
        
        
        
        private void Awake()
        {
            
            EventManager.Instance.AddListener<OnGamePlayEvent>(OnGamePlay);
            EventManager.Instance.AddListener<OnLog>(OnLog);
            EventManager.Instance.AddListener<BattleLog>(OnBattleLog);
            EventManager.Instance.AddListener<OnGameOver>(OnGameOver);
            
            
            ItemManager.Instance.Awake();
            InputManager.Instance.Awake();
            GridManager.Instance.Awake();
            ConfigManager.Instance.Awake();
            ViewManager.Instance.Awake();
        }

        private void OnGameOver(OnGameOver e)
        {
            _isGameStared = false;
            
            GridManager.Instance.Reset();
            ItemManager.Instance.Reset();
            ViewManager.Instance.Reset();
            
            _simulation.OnGameOver();
          
            _simulation = null;
            
           

            ItemManager.Instance.GenerateItem();
        }

      
        
        private void OnBattleLog(BattleLog e)
        {
            Debug.Log(e.Info);
        }

        private void OnLog(OnLog e)
        {
            Debug.Log(e.Info);
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

            _time += Time.deltaTime;
            
            _simulation.Update(Time.deltaTime*1000);
        }

        private float _time = 0;
        
        private void OnGamePlay(OnGamePlayEvent e)
        {
            _time = 0;
            
            GameUser user = new GameUser()
            {
                Items = ItemManager.Instance.GetAllItemData(),
                ActorId =  0,
            };

            var otherData = ItemManager.Instance.GetOtherData();
            
            GameUser user2 = new GameUser()
            {
                Items = otherData,
                ActorId =  1,
            };
            
            //创建UI
            
            ItemManager.Instance.GenerateItemForOther(otherData);
            
            _simulation = new Simulation(new GameUser[] { user,user2 });
            _isGameStared = true;
        }

        
        
    }
}