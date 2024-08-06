namespace Game.Game.Factory
{
    public class DecorateListenTypeSecondPass : IDecorate
    {
        public void Do(GameEntity e, int timConfigId)
        {
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.Game:

                 
                    
                    break;
                
            }
        }
    }
}