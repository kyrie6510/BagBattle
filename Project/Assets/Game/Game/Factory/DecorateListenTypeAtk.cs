namespace Game.Game.Factory
{
    public class DecorateListenTypeAtk : IDecorate
    {
        public void Do(GameEntity e, int timConfigId)
        {  
            if (!ConfigManager.Instance.IsHaveTimingConfig((short) timConfigId))
            {
                return;
            }
            
          
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);

            
            //
            if (!e.hasTimingTypeAtk)
            {
                e.AddTimingTypeAtk(0);    
            }

            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.Self:
                    e.AddGameTimingTypeAtkListener(e);
                    break;
            }



        }
    }
}