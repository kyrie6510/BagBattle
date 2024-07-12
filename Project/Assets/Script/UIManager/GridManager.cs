using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class GridManager: Singleton<GridManager>
    {
        private List<UIGrid> _grids = new List<UIGrid>();
        private List<GameObject> _gridAlphas = new List<GameObject>();
        private Dictionary<int, List<int>> _itemInGridInfoMap = new();
        private Dictionary<int, List<int>> _itemInGridBodyInfoMap = new();

        private int _rowNum = 7;
        private int _colNum = 9;
        
        public override void Awake()
        {
            var gridObj = GameObject.Find("BagGrid");
            var griAlphaObj = GameObject.Find("BagGridAlpha");

            for (int i = 0; i < gridObj.transform.childCount; i++)
            {
                var uiGrid = gridObj.transform.GetChild(i).GetComponent<UIGrid>();
                _grids.Add(uiGrid);
                uiGrid.Id = i;
                uiGrid.transform.GetChild(0).GetComponent<Text>().text = $"{i}";
            }
            
            for (int i = 0; i < griAlphaObj.transform.childCount; i++)
            {
                var obj = griAlphaObj.transform.GetChild(i).gameObject;
                _gridAlphas.Add(obj);
                obj.gameObject.SetActive(false);
                
            }
        }

        public UIGrid GetGrid(int x,int y)
        {
            if (x < 0 || y < 0) return null;
            
            var id = y * 9 + x;
            if (_grids.Count > id)
            {
                return _grids[id];
            }

            return null;
        }
        
        public void RefreshState(HashSet<UIGrid> touchGrids)
        {
            foreach (var grid in _grids)
            {
                grid.GetComponent<Image>().color = Color.cyan;
            }
            
            var sortTouchGrids = touchGrids.ToList();
            sortTouchGrids.Sort((grid1, grid2) => grid1.Id < grid2.Id ?  -1 :1  );
            
            if (sortTouchGrids.Count == 0) return;
            int index = 0;
            int startId = sortTouchGrids[0].Id;
            int startIdX = (startId) % _colNum;
            int startIdY = (startId) / _colNum;

            var curItem = InputManager.Instance.GetCurSelectItem();
            var curConfig = InputManager.Instance.GetCurSelectItemConfig();
            if(curItem==null) return;
            
            
            var gridTypeArray = ConfigManager.Instance.GetConfigGridTypeArray(curItem.ConfigId,curItem.RotateValue);
            
            //check
            for (int i = 0; i < gridTypeArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridTypeArray.GetLength(1); j++)
                {
                    
                    var type = gridTypeArray[i, j];
                    //安全校验
                    if (startIdX + j >= _colNum || startIdY + i >= _rowNum)
                    {
                        continue;
                    }

                    if (type == (int)ItemGridType.None||type == (int)ItemGridType.Target)
                    {
                        index++;
                        continue;
                    }

                    if (type == (int) ItemGridType.Star)
                    {
                        // index++;
                        // continue;
                    }

                    var curGrid = sortTouchGrids[index];
                    
                    var img = curGrid.GetComponent<Image>();
                    if (type == (int) ItemGridType.Body)
                    {
                       
                        
                        if (curConfig.PropType == PropType.Bag)
                        {
                            if (curGrid.LocalBagId == 0)
                            {
                                img.color = Color.green;
                            }
                            else
                            {
                                img.color = Color.red;
                            }
                        }
                        else
                        {
                            if (curGrid.LocalBagId == 0)
                            {
                                img.color = Color.red;
                            }
                            else
                            {
                                if (curGrid.LocalId==0)
                                {
                                    img.color = Color.green;
                                }
                                else
                                {
                                    img.color = Color.red;
                                }
                            }
                        }
                    }

                    if (type == (int) ItemGridType.Star)
                    {
                        if (curGrid.LocalId != 0)
                        {
                            var targetPropType = ItemManager.Instance.GetItem(curGrid.LocalId).PropType;

                            foreach (var triggerType in curConfig.TriggerStarType)
                            {
                                if (triggerType == (int) targetPropType)
                                {
                                    img.color = Color.yellow; 
                                }
                            }
                         
                        }
           
                    }
                    
                    
                    index++;
                    
                }
            }
        }
        
        private HashSet<UIGrid> _touchGrids = new HashSet<UIGrid>();
    
        public void AddTouchUIGrid(UIGrid grid)
        {
            this._touchGrids.Add(grid);
            if (InputManager.Instance.GetCurSelectItemGridCont() == _touchGrids.Count)
            {
               RefreshState(_touchGrids);
            }

        }

        public void RemoveTouchUIGrid(UIGrid grid)
        {
            this._touchGrids.Remove(grid);
            if (InputManager.Instance.GetCurSelectItemGridCont() == _touchGrids.Count)
            {
                RefreshState(_touchGrids);
            }
        }

        public void TouchClear()
        {
            _touchGrids.Clear();
            RefreshState(_touchGrids);
        }

        private bool CheckAndPut()
        {

            var curItem = InputManager.Instance.GetCurSelectItem();
            var curItemConfig = InputManager.Instance.GetCurSelectItemConfig();
            var touchGrids = _touchGrids.ToList();
            touchGrids.Sort((grid1, grid2) => grid1.Id < grid2.Id ?  -1 :1  );
            
            if (touchGrids.Count == 0) return false;
            int index = 0;
            int startId = touchGrids[0].Id;
      

            var gridTypeArray = ConfigManager.Instance.GetConfigGridTypeArray(curItem.ConfigId,curItem.RotateValue);
            
            int startIdX = (startId) % _colNum;
            int startIdY = (startId) / _colNum;
            
            //check
            for (int i = 0; i < gridTypeArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridTypeArray.GetLength(1); j++)
                {
                    
                    
                    var type = gridTypeArray[i, j];
                    
                    //安全校验
                    if (startIdX + j >= _colNum || startIdY + i >= _rowNum)
                    {
                        if (type == (int) ItemGridType.Body)
                        {
                            return false;
                        }
                        continue;
                    }
                    
                    //当前选中物品在该格子的格子类型
                    if (type == (int) ItemGridType.None || type == (int) ItemGridType.Star ||
                        type == (int) ItemGridType.Target)
                    {
                        index++;
                        continue;
                    }
                    
                    var curGrid = touchGrids[index];
                
                    if (type == (int)ItemGridType.Body)
                    {

                        if (curItemConfig.PropType == PropType.Bag)
                        {
                            if (curGrid.LocalBagId != 0)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (curGrid.LocalBagId == 0)
                            {
                                return false;
                            }
                            if (curGrid.LocalId != 0)
                            {
                                return false;
                            }
                        }
                    }
                    index++;
                }
            }
            
            
            //put data

            if (!_itemInGridInfoMap.TryGetValue(curItem.LocalId,out var insideGrids))
            {
                _itemInGridInfoMap.Add(curItem.LocalId,new List<int>());
                insideGrids = _itemInGridInfoMap[curItem.LocalId];
                
                _itemInGridBodyInfoMap.Add(curItem.LocalId,new List<int>());
                
            }
            insideGrids.Clear();
            _itemInGridBodyInfoMap[curItem.LocalId].Clear();

            index = 0;

            for (int i = 0; i < gridTypeArray.GetLength(0); i++)
            {
                for (int j = 0; j < gridTypeArray.GetLength(1); j++)
                {
                    
                    //安全校验
                    if (startIdX + j >= _colNum || startIdY + i >= _rowNum)
                    {
                        continue;
                    }
                    
                    var curGrid = touchGrids[index];
                    var type = gridTypeArray[i, j];
                    
                    if (type == (int) ItemGridType.Body)
                    {
                        //数据写入
                        if (curItemConfig.PropType == PropType.Bag)
                        {
                            curGrid.LocalBagId = curItem.LocalId;
                        }
                        else
                        {
                            curGrid.LocalId = curItem.LocalId;
                        }
                        
                        _itemInGridBodyInfoMap[curItem.LocalId].Add(curGrid.Id);
                        
                        //缓存物品在哪些格子信息
                        insideGrids.Add(curGrid.Id);
                    }
                
                    index++;
                    
                }
            }
            
            
            return true;
        }


        private void RemoveItemInGridInfo(int itemLocalId)
        {
            if (!_itemInGridInfoMap.TryGetValue(itemLocalId, out var grids))
            {
                return;
            }

            foreach (var id in grids)
            {
                _grids[id].RemoveInfo(itemLocalId);
            }
            
            SetAlphaGridByItemId(itemLocalId,false);
         
        }

        void SetAlphaGridByItemId(int itemLocalId,bool isOpen)
        {
            if (!_itemInGridBodyInfoMap.TryGetValue(itemLocalId, out var bodyGrids))
            {
                return;
            }

            foreach (var id in bodyGrids)
            {
                if (isOpen)
                {
                    _gridAlphas[id].SetActive(isOpen);
                }
                else
                {
                    if (_grids[id].LocalBagId == 0)
                    {
                        _gridAlphas[id].SetActive(isOpen);
                    }
                }
            }
        }
        
        
        public void OnDrop()
        {
            
            var curItem = InputManager.Instance.GetCurSelectItem();
            var curLocalId = curItem.LocalId;
            RemoveItemInGridInfo(curLocalId);
            
            if (CheckAndPut())
            {
                Debug.Log("可以放置");
                //显示打开
                ItemManager.Instance.OnItemSetToBag(curItem);
                SetAlphaGridByItemId(curLocalId,true);
                curItem.SetRigState(false);
            }
            else
            {
                //飞向盒子
                ItemManager.Instance.BackToBox(curItem);
                Debug.Log("不可以放置");
            }
            
            TouchClear();
        }
        
    }
}