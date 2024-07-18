using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.Collections.Generic;
using FlatBuffers;
using Script;

namespace Game
{
    public partial class  ConfigManager : Singleton<ConfigManager>
    {
        public override void Awake()
        {
            base.Awake();
            var data = Load<TablePropItemRowData>();
            
            foreach (var v in data)
            {
                Debug.Log(v.Key + ":"+ v.Value.PropType);
            }
            
        }

        private Assembly ass;
        
        public Dictionary<short, T> Load<T>()
        {
            
            ass = Assembly.Load("config-flat");
            
            var type1 = typeof(T);
            var type2Name = type1.Name.Substring(0, type1.Name.Length - 7);
            
            TextAsset studentTextAsset = Resources.Load<TextAsset>($"Data/{type2Name}");
            byte[] bytes = studentTextAsset.bytes;
        
            
            // var bytes =    
            //     Loader.LoadFile($"Config/bytes/{type2Name}.bytes");
            Dictionary<short, T> Dict = new Dictionary<short, T>();
            var type2 = ass.GetType(type2Name);
            var m = type2.GetMethod("GetRootAs" + type2Name, new Type[] { typeof(ByteBuffer) });
            var s1 = m.Invoke(type2, new object[] { new ByteBuffer(bytes) });
            var listMethod = type2.GetMethod("Datalist");
            listMethod.Invoke(s1, new object[] { 0 });
            //var lengthField = type2.GetField("DatalistLength");
            var lengthField = type2.GetProperty("DatalistLength");
            int len = (int)lengthField.GetValue(s1);
            var idFiled = type1.GetProperty("Id");
            for (int i = 0; i < len; i++)
            {
                T item = (T)listMethod.Invoke(s1, new object[] { i });
                short id = (short)idFiled.GetValue(item);
                Dict.Add(id, item);
            }
            
            return Dict;
        }
        
        
        
        
        public Dictionary<int, ConfigItem> ConfigMap = new Dictionary<int, ConfigItem>()
        {
            {
                1, new ConfigItem()
                {
                    PropType = PropType.MeleeWeapon,
                    Name = "木剑",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.Body},
                        {(int)ItemGridType.Body}
                    },
                    Width = 1,
                    Height = 2,
                    UIWidth = 1,
                    UIHeight = 2,
                    TexturePath = "WoodenSword", 
                }
                
            },

            {
                2, new ConfigItem()
                {
                    PropType = PropType.MeleeWeapon,
                    Name = "藤蔓",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.Body, (int)ItemGridType.Body,(int) ItemGridType.None},
                        {(int)ItemGridType.None, (int)ItemGridType.Body,(int) ItemGridType.None},
                        {(int)ItemGridType.None, (int)ItemGridType.Body,(int) ItemGridType.Body},
                    },
                    Center = new Vector2(1, 1),
                    Width = 3,
                    Height = 3,
                    UIWidth = 3,
                    UIHeight = 3,
                    TexturePath = "ThornWhip", 
                }
            },

            {
                3, new ConfigItem()
                {
                    PropType = PropType.Bag,
                    Name = "四格背包",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.Body, (int)ItemGridType.Body},
                        {(int)ItemGridType.Body, (int)ItemGridType.Body},
                    },
                    Center = new Vector2(1, 1),
                    Width = 2,
                    Height = 2,
                    UIWidth = 2,
                    UIHeight = 2,
                    TexturePath = "LeatherBag", 
                }
            },


            {
                4, new ConfigItem()
                {
                    PropType = PropType.Bag,
                    Name = "腰包",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.Body,(int) ItemGridType.Body},
                    },
                    Center = new Vector2(1, 1),
                    Width = 2,
                    Height = 1,
                    
                    UIWidth = 2,
                    UIHeight = 1,
                    TexturePath = "FannyPack", 
                }
            },

            {
                5, new ConfigItem()
                {
                    PropType = PropType.Food,
                    Name = "香蕉",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.None, (int)ItemGridType.Star,(int)ItemGridType.None,(int)ItemGridType.None},
                        {(int)ItemGridType.Star, (int)ItemGridType.Body,(int)ItemGridType.Star,(int)ItemGridType.None},
                        {(int)ItemGridType.Star, (int)ItemGridType.Body,(int)ItemGridType.Body,(int)ItemGridType.Star},
                        {(int)ItemGridType.None, (int)ItemGridType.Star,(int)ItemGridType.Star,(int)ItemGridType.None},
                    },
                    Center = new Vector2(0, -0.25f),
                    Width = 4,
                    Height = 4,
                    
                    UIWidth = 2,
                    UIHeight = 2,
                    TexturePath = "Banana",
                    TriggerStarType = new []{(int)PropType.Food},
                }
            },
            
            {
                6, new ConfigItem()
                {
                    PropType = PropType.Food,
                    Name = "蘑菇",
                    GridType = new int[,]
                    {
                        {(int)ItemGridType.None, (int)ItemGridType.Star,(int)ItemGridType.None},
                        {(int)ItemGridType.Star, (int)ItemGridType.Body,(int)ItemGridType.Star},
                        {(int)ItemGridType.Star, (int)ItemGridType.Body,(int)ItemGridType.Star},
                        {(int)ItemGridType.None, (int)ItemGridType.Star,(int)ItemGridType.None},
                    },
                    Center = new Vector2(0, -0.25f),
                    Width = 3,
                    Height = 4,
                    
                    UIWidth = 1,
                    UIHeight = 2,
                    TexturePath = "FlyAgaric",
                    TriggerStarType = new []{(int)PropType.Food},
                }
            },
        };

        
        

        
        
        
        public ConfigItem GetConfigItem(int id)
        {
            if (ConfigMap.ContainsKey(id))
            {
                return ConfigMap[id];
            }

            return null;
        }
    }
}