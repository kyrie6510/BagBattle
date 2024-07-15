using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class GridManager: Singleton<GridManager>
    {
        //UI
        private List<UIGrid> _grids = new List<UIGrid>();
        private List<GameObject> _gridViews = new List<GameObject>();
        private List<GameObject> _gridStars = new List<GameObject>();
        
        //数据
        private Dictionary<int, List<int>> _itemInGridInfoMap = new();
        private Dictionary<int, List<int>> _itemInGridBodyInfoMap = new();
        private Dictionary<int, List<int>> _itemStarInfoMap = new();


        private List<UIDataGrid> _gridsData = new List<UIDataGrid>();

        private int _rowNum = 7;
        private int _colNum = 9;
        
        public override void Awake()
        {
            var gridObj = GameObject.Find("BagGrid");
            var gridViewObj = GameObject.Find("BagGridView");
            var gridStarObj = GameObject.Find("BagStarView");
            
            for (int i = 0; i < gridObj.transform.childCount; i++)
            {
                var uiGrid = gridObj.transform.GetChild(i).GetComponent<UIGrid>();
                _grids.Add(uiGrid);
                uiGrid.Id = i;
                uiGrid.transform.GetChild(0).GetComponent<Text>().text = $"{i}";

                UIDataGrid dataGrid = new UIDataGrid()
                {
                    Id = i
                };
                _gridsData.Add(dataGrid);

            }
            
            for (int i = 0; i < gridViewObj.transform.childCount; i++)
            {
                var obj = gridStarObj.transform.GetChild(i).gameObject;
                _gridViews.Add(obj);
                obj.gameObject.SetActive(false);
            }
            
            for (int i = 0; i < gridStarObj.transform.childCount; i++)
            {
                var obj = gridStarObj.transform.GetChild(i).gameObject;
                _gridStars.Add(obj);
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

        private HashSet<int> _tempStarMap = new HashSet<int>();
        
        public void RefreshState()
        {
            HashSet<UIGrid> touchGrids = _touchGrids;
            
            foreach (var grid in _grids)
            {
                grid.GetComponent<Image>().color = Color.cyan;
            }
            
            foreach (var star in _gridStars)
            {
                star.gameObject.SetActive(false);
            }
            _tempStarMap.Clear();
            
            
            var sortTouchGrids = touchGrids.ToList();
            sortTouchGrids.Sort((grid1, grid2) => grid1.Id < grid2.Id ?  -1 :1  );
            
            if (sortTouchGrids.Count == 0) return;
            int index = 0;
            int startId = sortTouchGrids[0].Id;
            int startIdX = (startId) % _colNum;
            int startIdY = (startId) / _colNum;

            int curSelectItemId = InputManager.Instance.GetCurSelectItemId();
            
            var curItem = ItemManager.Instance.GetItemData(curSelectItemId);
            var curConfig = ConfigManager.Instance.GetConfigItem(curItem.ConfigId);
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

                    if (index >= sortTouchGrids.Count)
                    {
                        Debug.Log("dadada");
                    }
                    
                    var curGridUI = sortTouchGrids[index];
                    var curGridData = _gridsData[curGridUI.Id];
                    
                    
                    var img = curGridUI.GetComponent<Image>();
                    if (type == (int) ItemGridType.Body)
                    {
                        if (curConfig.PropType == PropType.Bag)
                        {
                            if (curGridData.LocalIdBag == 0)
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
                            if (curGridData.LocalIdBag == 0)
                            {
                                img.color = Color.red;
                            }
                            else
                            {
                                if (curGridData.LocalIdItem==0)
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
                        if (curGridData.LocalIdItem != 0)
                        {
                            var targetPropType = ItemManager.Instance.GetItem(curGridData.LocalIdItem).PropType;

                            foreach (var triggerType in curConfig.TriggerStarType)
                            {
                                if (!_tempStarMap.Contains(curGridData.LocalIdItem)&&triggerType == (int) targetPropType)
                                {
                                    _gridStars[curGridUI.Id].SetActive(true);
                                    _tempStarMap.Add(curGridData.LocalIdItem);
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
               RefreshState();
            }

        }

        public void RemoveTouchUIGrid(UIGrid grid)
        {
            this._touchGrids.Remove(grid);
            if (InputManager.Instance.GetCurSelectItemGridCont() == _touchGrids.Count)
            {
                RefreshState();
            }
        }

        public void TouchClear()
        {
            _touchGrids.Clear();
            RefreshState();
        }

        private bool CheckAndPut()
        {

            var curLocalId = InputManager.Instance.GetCurSelectItemId();
            
            var curItemData = ItemManager.Instance.GetItemData(curLocalId);
            var curItemConfig = ConfigManager.Instance.GetConfigItem(curItemData.ConfigId);
            var touchGrids = _touchGrids.ToList();
            touchGrids.Sort((grid1, grid2) => grid1.Id < grid2.Id ?  -1 :1  );
            
            if (touchGrids.Count == 0) return false;
            int index = 0;
            int startId = touchGrids[0].Id;
      

            var gridTypeArray = ConfigManager.Instance.GetConfigGridTypeArray(curItemData.ConfigId,curItemData.RotateValue);
            
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

                    if (index >= touchGrids.Count)
                    {
                        Debug.Log("faffa");
                    }
                    
                    var curGridUI = touchGrids[index];
                    var curGridData = _gridsData[curGridUI.Id];
                    
                    if (type == (int)ItemGridType.Body)
                    {

                        if (curItemConfig.PropType == PropType.Bag)
                        {
                            if (curGridData.LocalIdBag != 0)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (curGridData.LocalIdBag  == 0)
                            {
                                return false;
                            }
                            if (curGridData.LocalIdItem != 0)
                            {
                                return false;
                            }
                        }
                    }
                    index++;
                }
            }
            
            
            //put data

            if (!_itemInGridInfoMap.TryGetValue(curItemData.LocalId,out var insideGrids))
            {
                _itemInGridInfoMap.Add(curItemData.LocalId,new List<int>());
                insideGrids = _itemInGridInfoMap[curItemData.LocalId];
                
                _itemInGridBodyInfoMap.Add(curItemData.LocalId,new List<int>());
                
            }
            insideGrids.Clear();
            _itemInGridBodyInfoMap[curItemData.LocalId].Clear();

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
                    
                    var curGridUI = touchGrids[index];
                    var curGridData = _gridsData[curGridUI.Id];
                
                    var type = gridTypeArray[i, j];

                    if (type == (int) ItemGridType.Star)
                    {
                        if (curGridData.LocalIdItem != 0)
                        {
                            var targetPropType = ItemManager.Instance.GetItem(curGridData.LocalIdItem).PropType;

                            foreach (var triggerType in curItemConfig.TriggerStarType)
                            {
                                if (!curItemData.StarTargetLocalId.Contains(curGridData.LocalIdItem)&&triggerType == (int) targetPropType)
                                {
                                    _gridStars[curGridUI.Id].SetActive(true);
                                    curItemData.StarTargetLocalId.Add(curGridData.LocalIdItem);
                                }
                            }
                         
                        }
                    }
                    
                    if (type == (int) ItemGridType.Body)
                    {
                        //数据写入
                        if (curItemConfig.PropType == PropType.Bag)
                        {
                            curGridData.LocalIdBag = curItemData.LocalId;
                        }
                        else
                        {
                            curGridData.LocalIdItem = curItemData.LocalId;
                        }
                        
                        _itemInGridBodyInfoMap[curItemData.LocalId].Add(curGridUI.Id);
                        
                        //缓存物品在哪些格子信息
                        insideGrids.Add(curGridUI.Id);
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
                _gridsData[id].RemoveInfo(itemLocalId);
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
                    _gridViews[id].SetActive(isOpen);
                }
                else
                {
                    if (_gridsData[id].LocalIdBag == 0)
                    {
                        _gridViews[id].SetActive(isOpen);
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