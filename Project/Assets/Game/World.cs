using System.Collections.Generic;
using Game.Actor;
using Game.Buff;
using Game.Combat;
using Game.Game;
using Game.Generated;
using UnityEngine;

namespace Game
{
    public class World
    {
        private GameFeature _systems;
        
        internal int Tick;

        public World(GameUser[] actors)
        {
           

            
            
            _systems = new GameFeature("world");
            _systems.Add(new GameSystem());
            _systems.Add(new CombatSystem());
            _systems.Add(new BuffSystem());
            _systems.Add(new ActorSystem(actors));
            
            _systems.Initialize();
        }


        private float time = 0;

        public void Update()
        {
            time += UnityEngine.Time.deltaTime;
            if (time >= 1)
            {
                time = 0;
                EventManager.Instance.TriggerEvent(new OnLog($"Tick:{Tick}"));
            }
            
            Tick++;

            EventManager.Instance.TriggerEvent(new OnWorldTick(){Tick = Tick});
            
            _systems.Execute();
            _systems.Cleanup();

        }

        public void Reset()
        {
            
            
             
            _systems.TearDown();
            _systems.DeactivateReactiveSystems();
            _systems = null;
            
            Contexts.sharedInstance.Reset();
            
            // Contexts.sharedInstance.actor.DestroyAllEntities();
            // Contexts.sharedInstance.combat.DestroyAllEntities();
            // Contexts.sharedInstance.game.DestroyAllEntities();
            
            Tick = 0;
        }
    }
}