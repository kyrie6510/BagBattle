﻿namespace Game
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