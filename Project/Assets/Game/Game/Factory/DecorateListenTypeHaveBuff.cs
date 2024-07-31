namespace Game.Game.Factory
{
    public class DecorateListenTypeHaveBuff : IDecorate
    {
        public void Do(GameEntity e, int timConfigId)
        {
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);

            
            
            
            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.MyActor:
                    var actor = Contexts.sharedInstance.actor.GetEntityWithId(e.actorId.Value);
                    if (actor.hasTimingTypeHaveBuff)
                    {
                        // actor.AddTimingTypeHaveBuff(new());
                    }
                    //actor.timingTypeHaveBuff.
                    
                    break;
                
            }

        }
    }
}