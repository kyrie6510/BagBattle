﻿using System.Collections.Generic;
using System.Linq;
using Script.Event;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class GridManager : Singleton<GridManager>
    {
        //UI
        private List<UIGrid> _grids = new List<UIGrid>();
        private List<GameObject> _gridViews = new List<GameObject>();
        private List<GameObject> _gridStars = new List<GameObject>();

        //数据
        /// <summary>
        /// itemLocalId gridId
        /// </summary>
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

            EventManager.Instance.AddListener<OnItemSelectEvent>(OnItemSelectFunction);


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

        private void OnItemSelectFunction(OnItemSelectEvent e)
        {
            RemoveItemInGridInfo(e.LocalId);
        }

        
        
        public void SetTouchGrid(Vector2 quadMin, Vector2 quadMax)
        {
            _touchGrids.Clear();

            HashSet<UIGrid> touchGrids = _touchGrids;

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
            var curConfig = ConfigManager.Instance.GetConfigItem(curItem.ConfigId);
            var gridTypeArray = ConfigManager.Instance.GetConfigGridTypeArray(curItem.ConfigId, curItem.RotateValue);
            
            // int x = 0;
            // int y = 0;

            for (int j = (int) quadMin.y,y = 0; j > quadMax.y; j-- , y++)
            {
                for (int i = (int) quadMin.x, x=0; i < quadMax.x; i++ , x++)
                {
                    var uiGrid = GetGridId(i, j);
                    
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

                        if (curConfig.PropType == PropType.Bag)
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
                            var targetPropType = ItemManager.Instance.GetItem(curGridData.LocalIdItem).PropType;

                            if (curConfig.TriggerStarType.Contains((int) targetPropType) &&
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
        public UIGrid GetGridId(int x, int y)
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

        private HashSet<UIGrid> _touchGrids = new HashSet<UIGrid>();

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
        }


        public void OnDrop()
        {
            var curItem = InputManager.Instance.GetCurSelectItem();

            if (_isCanPutData)
            {
                PutData();


                //显示打开
                ItemManager.Instance.OnItemSetToBag(curItem);
                foreach (var gridId in _catchStarGrids)
                {
                    _gridStars[gridId].gameObject.SetActive(false);
                }
            }
            else
            {
                //飞向盒子
                ItemManager.Instance.BackToBox(curItem);
            }

            var info = _isCanPutData ? "可以放置" : "不可以放置";
            Debug.Log(info);
        }
    }
}