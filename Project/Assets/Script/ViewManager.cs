using Entitas.Unity;
using Game;
using UnityEngine;

namespace Script
{
    public class ViewManager : Singleton<ViewManager>
    {
        private ViewActor _actor1;
        private ViewActor _actor2;
        
        public override void Awake()
        {
            base.Awake();

            _actor1 = GameObject.Find("ViewActor_1").GetComponent<ViewActor>();
            _actor2 = GameObject.Find("ViewActor_2").GetComponent<ViewActor>();
            
            EventManager.Instance.AddListener<OnActorEntityCreat>(OnActorEntityCreat);
            EventManager.Instance.AddListener<OnGameEntityCreat>(OnGameEntityCreat);
            
        }

        private void OnGameEntityCreat(OnGameEntityCreat e)
        {
            var view = ItemManager.Instance.GetItemUI(e.ViewLocalId);
            view.SetGameEntity(e.Entity);

        }

        public void Reset()
        {
            _actor1.gameObject.Unlink();
            _actor2.gameObject.Unlink();
        }

        private void OnActorEntityCreat(OnActorEntityCreat e)
        {
            if (e.ActorId == 0)
            {
                _actor1.SetActorEntity(e.ActorEntity);
            }
            else
            {
                _actor2.SetActorEntity(e.ActorEntity);
            }
        }
    }
}