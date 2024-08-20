using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class GridManager : Singleton<GridManager>
    {
        //UI
        private List<ViewGrid> _grids = new List<ViewGrid>();
        private List<GameObject> _gridViews = new List<GameObject>();
        private List<GameObject> _gridStars = new List<GameObject>();

        //数据
        /// <summary>
        /// itemLocalId gridId
        /// </summary>
        private Dictionary<int, List<int>> _itemInGridInfoMap = new();
        private List<UIDataGrid> _gridsData = new List<UIDataGrid>();

        private int _rowNum = 7;
        private int _colNum = 9;

        public override void Awake()
        {
            var gridObj = GameObject.Find("BagGrid");
            var gridViewObj = GameObject.Find("BagGridView");
            var gridStarObj = GameObject.Find("BagStarView");

            EventManager.Instance.AddListener<OnItemSelectEvent>(OnItemSelectFunction);


            for (int i = 0; i < gridObj.transform.childCount; i++)
            {
                var uiGrid = gridObj.transform.GetChild(i).GetComponent<ViewGrid>();
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

        private void OnItemSelectFunction(OnItemSelectEvent e)
        {
            RemoveItemInGridInfo(e.LocalId);
        }

        public void Reset()
        {
            _catchStarLocalIdMap.Clear();
            _catchBodyGrids.Clear();
            _catchStarGrids.Clear();

            foreach (var dataGrid in _gridsData)
            {
                dataGrid.Reset();
            }
            _itemInGridInfoMap.Clear();
        }
        
        
        public void SetTouchGrid(Vector2 quadMin, Vector2 quadMax)
        {
            _touchGrids.Clear();

            HashSet<ViewGrid> touchGrids = _touchGrids;

            //InitData
            _catchStarLocalIdMap.Clear();
            _catchBodyGrids.Clear();
            _catchStarGrids.Clear();
            SetCanPut(true);
            
            
            //UI Init
            foreach (var grid in _grids)
            {
                grid.GetComponent<Image>().color = Color.cyan;
            }

            foreach (var star in _gridStars)
            {
                star.gameObject.SetActive(false);
            }
            
            int curSelectItemId = InputManager.Instance.GetCurSelectItemId();
            var curItem = ItemManager.Instance.GetItemData(curSelectItemId);
            var curConfig = ConfigManager.Instance.GetPropConfig(curItem.ConfigId);
            var gridTypeArray = ConfigManager.Instance.GetConfigGridTypeArray((short)curItem.ConfigId, curItem.RotateValue);
            
            // int x = 0;
            // int y = 0;

            for (int j = (int) quadMin.y,y = 0; j > quadMax.y; j-- , y++)
            {
                for (int i = (int) quadMin.x, x=0; i < quadMax.x; i++ , x++)
                {
                    var uiGrid = GetGridId(i, j);

                    if (y >= gridTypeArray.GetLength(0))
                    {
                        int id = 0;
                        if (uiGrid != null)
                        {
                            id = uiGrid.Id;
                        }
                        Debug.LogError($"id{id} wrongy{y}");
                    }

                    if (x >= gridTypeArray.GetLength(1))
                    {
                        int id = 0;
                        if (uiGrid != null)
                        {
                            id = uiGrid.Id;
                        }
                        Debug.LogError($"id{id} wrongx{x}");
                    }
                    
                    var type = gridTypeArray[y,x];
                    
                    if (uiGrid == null)
                    {
                        if (type == (int) ItemGridType.Body)
                        {
                            SetCanPut(false);
                        }
                        
                        continue;
                    }
                    
                    if (type == (int) ItemGridType.None || type == (int) ItemGridType.Target)
                    {
                        continue;
                    }
                    
                    
                    var curGridUI = uiGrid;
                   
                    
                    var curGridData = _gridsData[curGridUI.Id];

                    var img = curGridUI.GetComponent<Image>();
                    if (type == (int) ItemGridType.Body)
                    {
                        _catchBodyGrids.Add(curGridData.Id);

                        if (curConfig.PropType == (int)PropType.Bag)
                        {
                            if (curGridData.LocalIdBag == 0)
                            {
                                img.color = Color.green;
                            }
                            else
                            {
                                SetCanPut(false);
                                img.color = Color.red;
                            }
                        }
                        else
                        {
                            if (curGridData.LocalIdBag == 0)
                            {
                                SetCanPut(false);
                                img.color = Color.red;
                            }
                            else
                            {
                                if (curGridData.LocalIdItem == 0)
                                {
                                    img.color = Color.green;
                                }
                                else
                                {
                                    SetCanPut(false);
                                    img.color = Color.red;
                                }
                            }
                        }
                    }

                    if (type == (int) ItemGridType.Star)
                    {
                        if (curGridData.LocalIdItem != 0)
                        {
                            var localId = curGridData.LocalIdItem;
                            var targetPropType = ItemManager.Instance.GetItemPropType(localId);
                            var targetConfigId = ItemManager.Instance.GetItemPropConfigId(localId);
                            if (
                                //TODO  表里添加 TriggerStarType
                                curConfig.GetTarStarTypeArray().Contains(targetPropType) &&
                                !curConfig.GetExTarStarIdArray().Contains(targetConfigId)&&
                                !_catchStarLocalIdMap.Contains(curGridData.LocalIdItem))
                            {
                                _gridStars[curGridUI.Id].SetActive(true);

                                _catchStarLocalIdMap.Add(curGridData.LocalIdItem);
                                _catchStarGrids.Add(curGridData.Id);
                            }
                        }
                    }
                    
                }
            }

            string info = "";
            foreach (var uiGrid in _touchGrids)
            {
                info += $"Id:{uiGrid.Id} ";
            }

            //ClearConsole();
            Debug.Log(info);
        }


        /// <summary>
        ///  x y 必须在第二象限
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public ViewGrid GetGridId(int x, int y)
        {
            if (x < 0 || y > 0) return null;
            if (x >= _colNum || y >= _rowNum) return null;

            y = Mathf.Abs(y);

            var id = y * 9 + x;
            if (_grids.Count > id)
            {
                return _grids[id];
            }

            return null;
        }

        private bool _isCanPutData = false;

        private HashSet<ViewGrid> _touchGrids = new HashSet<ViewGrid>();

        //缓存相关
        //当前选中物提buffer对象
        private HashSet<int> _catchStarLocalIdMap = new HashSet<int>();

        //当前选中物体的bodyGris
        private HashSet<int> _catchBodyGrids = new HashSet<int>();

        //当前选中物体的starGrids
        private HashSet<int> _catchStarGrids = new HashSet<int>();


        private void SetCanPut(bool isCanPut)
        {
            _isCanPutData = isCanPut;
        }
        
        public void TouchClear()
        {
            _touchGrids.Clear();
        }


        private void PutData()
        {
            if (!_isCanPutData) return;

            var curItemUI = InputManager.Instance.GetCurSelectItem();
            if (curItemUI == null) return;

            var curItemData = ItemManager.Instance.GetItemData(curItemUI.LocalId);
            if (curItemData == null) return;

            var localID = curItemData.LocalId;

            if (!_itemInGridInfoMap.TryGetValue(localID, out var itemInGrids))
            {
                itemInGrids = new List<int>();
                _itemInGridInfoMap.Add(localID, itemInGrids);
            }

            itemInGrids.Clear();

            foreach (var id in _catchBodyGrids)
            {
                _gridsData[id].PutItemData(curItemUI.LocalId, curItemUI.ConfigId);
                itemInGrids.Add(id);
            }


            curItemData.StarTargetLocalId.Clear();
            foreach (var id in _catchStarLocalIdMap)
            {
                curItemData.StarTargetLocalId.Add(id);
            }
        }


        /// <summary>
        /// 当前选中道具选中之前所在的格子数据
        /// </summary>
        private HashSet<int> _catchCurSelectLastPosGrids = new HashSet<int>();
        
        private void RemoveItemInGridInfo(int itemLocalId)
        {
            if (!_itemInGridInfoMap.TryGetValue(itemLocalId, out var grids))
            {
                return;
            }

            _catchCurSelectLastPosGrids.Clear();
            
            foreach (var id in grids)
            {
                _gridsData[id].RemoveInfo(itemLocalId);
                _catchCurSelectLastPosGrids.Add(id);

            }
        }


        public void OnDrop()
        {
            var curItem = InputManager.Instance.GetCurSelectItem();
            var curData = ItemManager.Instance.GetItemData(curItem.LocalId);
            if (_isCanPutData)
            {
                PutData();

                curData.LocalPos = curItem.gameObject.transform.localPosition;
                
                //显示打开
                ItemManager.Instance.OnItemSetToBag(curItem);
                foreach (var gridId in _catchStarGrids)
                {
                    _gridStars[gridId].gameObject.SetActive(false);
                }
            }
            else
            {
                
                curData.LocalPos = Vector2.zero;

                //飞向盒子
                ItemManager.Instance.BackToBox(curItem.LocalId);
                var config = ConfigManager.Instance.GetPropConfig((short)curItem.ConfigId);
                if (config.PropType == (int)PropType.Bag)
                {
                    //如果当前选中为背包,则需要移除在背包中的物品
                    foreach (var gridId in _catchCurSelectLastPosGrids)
                    {
                        var gridData = _gridsData[gridId];
                        var bagItemLocalId = gridData.LocalIdItem;
                        if (bagItemLocalId!= 0)
                        {
                            gridData.LocalIdItem = 0;
                            ItemManager.Instance.BackToBox(bagItemLocalId);
                        }
                    }
                }
                
              
                
            }

            var info = _isCanPutData ? "可以放置" : "不可以放置";
            Debug.Log(info);
        }
    }
}