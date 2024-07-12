using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    /// <summary>
    /// 物品中的格子类型
    /// </summary>
    public enum ItemGridType
    {
        None = 0,
        Body = 1,
        Star = 2,
        Target  = 3,
    }
    
    /// <summary>
    /// 物品中的格子类型
    /// </summary>
    public enum PropType
    {
        Bag = 0,
        Weapon = 1,
        Fruits = 2,
    }
    
    
    public class ConfigItem
    {
        // public List<ItemGridType> GridType = new List<ItemGridType>();

        public int[,] GridType;
        
        public Vector2 Center  = Vector2.zero;

        public string Name;

        
        public PropType PropType;

        public int Width;
        public int Height;

        public int UIWidth;
        public int UIHeight;

        public string TexturePath;

        //触发星物品的星物品类型
        public int[] TriggerStarType;


    }
}