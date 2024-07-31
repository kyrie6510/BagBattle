namespace Game.Game.Factory
{
    public class DecorateListenTypeAtk : IDecorate
    {
        public void Do(GameEntity e, int timConfigId)
        {
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);

            if (!e.hasTimingTypeAtk)
            {
                e.AddTimingTypeAtk(0,timConfig.ListenType);    
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