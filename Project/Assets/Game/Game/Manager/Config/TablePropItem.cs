using System.Collections.Generic;

namespace Game
{
    public partial class  ConfigManager
    {
        private Dictionary<short, TablePropItemRowData> _itemMap;
        private Dictionary<short, int[,]> _itemGridTypeMap = new Dictionary<short, int[,]>();
        
        /// <summary>
        /// <itemConfigID,<timId,EffectID>>
        /// </summary>
        private Dictionary<short, Dictionary<int,List<int>>> _itemTimForEffect = new ();
        
        public TablePropItemRowData GetPropConfig(short id)
        {
            LoadPropItem();
            return _itemMap[id];
        }

        public Dictionary<int, List<int>> GetConfigTimEffectInfo(short configId)
        {
            return _itemTimForEffect[configId];
        }
        

        private void LoadPropItem()
        {
            
            if (_itemMap == null)
            {
                _itemMap = Load<TablePropItemRowData>();
              
                foreach (var kv in _itemMap)
                {
                    //格子类型
                    var config = kv.Value;
                    var configId = kv.Key;
                    int[,] array = new int[config.Height, config.Width];

                    int index = 0;
                    
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = config.GetItemGridTypeArray()[index];
                            index++;
                        }
                    }
                    _itemGridTypeMap.Add(configId,array);
                    
                    //时机效果映射图
                    var timArray = config.GetTimIdArray();
                    var flashArray = config.GetEffectOfListenArray();
                    var effectIndex = 0;
                    var effectArray = config.GetEffectIdArray();
                    
                    _itemTimForEffect.Add(configId,new Dictionary<int, List<int>>());
                    
                    for (int i = 0; i < timArray.Length; i++)
                    {
                        var timId = timArray[i];
                        var length = flashArray[i];
                        
                        _itemTimForEffect[configId].Add(timId,new List<int>());
                        for (int j = 0; j < length; j++)
                        {
                            _itemTimForEffect[configId][timId].Add(effectArray[effectIndex]);
                            effectIndex++;
                        }
                    }
                }
            }
        }
        
        public int[,] GetConfigGridTypeArray(short configId,int rotateValue)
        {
            LoadPropItem();
            
            if (!_itemGridTypeMap.ContainsKey(configId))
            {
                return null;
            }

            var config = _itemMap[configId];
            var configItemGridType = _itemGridTypeMap[configId];
            
            if (rotateValue == 0 || rotateValue == 360) return configItemGridType;
            
            int m = configItemGridType.GetLength(0);
            int n = configItemGridType.GetLength(1);
            
            //行列不等要开辟新的数组
            if(config.Width != config.Height && rotateValue != 0 && rotateValue != 180)
            {
                // 创建一个 n × m 的数组
                int[,] result = new int[n, m];
                Rotate(configItemGridType, result, rotateValue);
                return result;
            }
            else
            {
                // 创建一个 m × n 的数组
                int[,] result = new int[m, n];
                Rotate(configItemGridType, result, rotateValue);
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
        
        
        
    }
   
}