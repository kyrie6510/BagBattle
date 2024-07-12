using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class ConfigManager : Singleton<ConfigManager>
    {
        public Dictionary<int, ConfigItem> ConfigMap = new Dictionary<int, ConfigItem>()
        {
            {
                1, new ConfigItem()
                {
                    PropType = PropType.Weapon,
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
                    PropType = PropType.Weapon,
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
                    PropType = PropType.Fruits,
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
                    TriggerStarType = new []{(int)PropType.Fruits},
                }
            },
            
            {
                6, new ConfigItem()
                {
                    PropType = PropType.Fruits,
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
                    TriggerStarType = new []{(int)PropType.Fruits},
                }
            },
        };

        
        

        public int[,] GetConfigGridTypeArray(int configId,int rotateValue)
        {
            
            if (!ConfigMap.ContainsKey(configId))
            {
                return null;
            }
            
            var config = ConfigMap[configId];
            
            if (rotateValue == 0 || rotateValue == 360) return config.GridType;
            
            int m = config.GridType.GetLength(0);
            int n = config.GridType.GetLength(1);
            
            //行列不等要开辟新的数组
            if(config.Width != config.Height && rotateValue != 0 && rotateValue != 180)
            {
                // 创建一个 n × m 的数组
                int[,] result = new int[n, m];
                Rotate(config.GridType, result, rotateValue);
                return result;
            }
            else
            {
                // 创建一个 m × n 的数组
                int[,] result = new int[m, n];
                Rotate(config.GridType, result, rotateValue);
                return result;
            }
            
        }

        private void Rotate(int [,] inputArray,int[,]  rotatedArray,int angle)
        {
            int rows = inputArray.GetLength(0);
            int cols = inputArray.GetLength(1);
            
            switch (angle)
            {
                case 90:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            rotatedArray[j, rows - 1 - i] = inputArray[i, j];
                        }
                    }
                    break;
                case 180:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            rotatedArray[rows - 1 - i, cols - 1 - j] = inputArray[i, j];
                        }
                    }
                    break;
                case 270:
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            rotatedArray[cols - 1 - j, i] = inputArray[i, j];
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        
        
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