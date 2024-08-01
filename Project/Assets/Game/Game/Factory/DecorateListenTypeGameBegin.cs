namespace Game.Game.Factory
{
    public class DecorateListenTypeGameBegin: IDecorate
    {
        public void Do(GameEntity e, int timConfigId)
        {
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.Game:

                    if (!e.hasTimingTypeSecondPass)
                    {
                        e.AddTimingTypeSecondPass(timConfig.ListenValue(0),0);
                    }
                    
                    break;
                
            }
        }
    }
}