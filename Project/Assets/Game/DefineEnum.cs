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
       Atked =3,//被攻击后
       Active=4,//激活时 
       GetBuff =5,//获得n层b时 
       HpLess =6,//生命值低于n时 
       HaveBuf =7,//拥有n层b时 
       GameBegin =8,//战斗开始 
       TriggerNum =9,//战斗触发n次 
       SecondPass =10,//每n秒 
       InState =11,//进入xx状态
       InStore =12,//进入商店
       EverHaveBuff=13,//每拥有一层b
    }
    //
    // 1.充能
    // 2.狂热
    // 3.幸运
    // 4.魔法
    // 5.回复
    // 6.尖刺
    // 7.吸血
    // 8.致盲
    // 9.冰冷
    // 10.中毒
    // 11.护盾
    
    // 12.治疗
    // 13.疲惫
    // 14.无敌
    // 15.无效 : 防止获得增益
    // 16.反弹 : 把减益施加给对手
    // 17.复活 : 恢复生命值
    // 19.抵挡:放置获得减益
    // 20.眩晕:暂停所有物品冷却时间
    public enum BuffType
    {
        Empower_1 = 1,  // 1.充能
        Heat_2 = 2, // 2.狂热
        Luck_3 = 3, // 3.幸运
        Mana_4 = 4, // 4.魔法
        Regeneration_5, // 5.回复
        Spikes_6, // 6.尖刺
        Vampirism_7,// 7.吸血
        Blind_8,// 8.致盲
        Cold_9,// 9.冰冷
        Poison_10,// 10.中毒
        Block_11 // 11.护盾
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
        OtherActorWeapon = 8, //对手武器物品
        OtherActorMeleeWeapon = 9,//对手近战武器
    }
    
    public enum EffectType
    {
        TakDamage = 1, 
        Attribute = 2, 
        AddBuff = 3, 
        Active = 4, 
        PlayerAttribute = 5, 
        Special = 6, 
        Defend = 7,
     
    }
}