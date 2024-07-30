namespace Game
{
    /// <summary>
    /// 物品中的格子类型
    /// </summary>
    public enum ItemGridType
    {
        None = 0,
        Body = 1,
        Star = 2,
        Target = 3,
    }

    /// <summary>
    /// 物品中的格子类型
    /// </summary>
    public enum PropType
    {
        Bag = 0,
        MeleeWeapon = 1,
        RangedWeapon = 2,
        Food = 3,
        Accessory = 4, //配饰
        GemStone = 5, //宝石
        Pet = 6, //宠物
        Potion = 7, //药水
        Card = 8, //卡牌
        Shield = 9, //盾牌
        Glove = 10, //手套
    }
    // 1.攻击时 
    // 2.未命中时 
    // 3.命中时 
    // 4.激活时 
    // 5.获得n层b时 
    // 6.生命值低于n时 
    // 7.拥有n层b时 
    // 8.战斗开始 
    // 9.战斗触发n次 
    // 10.每n秒 
    // 11.进入xx状态
    // 12.进入商店

    public enum ListenType
    {
       Atking =1,//攻击时 
       AtkMis =2,//未命中时 
       Atked =3,//命中时 
       Active=4,//激活时 
       GetBuff =5,//获得n层b时 
       HpLess =6,//生命值低于n时 
       HaveBuf =7,//拥有n层b时 
       GameBegin =8,//战斗开始 
       TriggetNum =9,//战斗触发n次 
       SecondPass =10,//每n秒 
       InState =11,//进入xx状态
       InStore =12,//进入商店
        
        
        
        
    }
    
    public enum ListenTarget
    {
        Self = 1, //自身物品 
        MyActor = 2, //玩家自己
        OtherActor = 3, //对手玩家
        Star = 4, //星物品
        Square = 5, //方块物品
        Game = 6, //本场游戏 
        Bag = 7, //包内物品
    }
}