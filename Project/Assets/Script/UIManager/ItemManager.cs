using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using Game;
using Script.Event;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace Script
{
    public class ItemManager: Singleton<ItemManager>
    {
        public List<GameObject> _prefabs;
        public GameObject BagItem;
        public GameObject PropItem;
        public GameObject BoxObj;

        private Dictionary<int, ConfigItem> _itemMap = new Dictionary<int, ConfigItem>();
        private Dictionary<int, UIDataItem> _itemDataMap = new Dictionary<int, UIDataItem>();
        private Dictionary<int, ViewItem> _itemUIMap = new Dictionary<int, ViewItem>();
        private int _localId = 1;

        private UIDataItem _curSelectItemData;
        
        public override void Awake()
        {
            base.Awake();
            
            EventManager.Instance.AddListener<OnItemSelectEvent>(OnItemSelectFunction);
            
            
            _prefabs = new List<GameObject>();
            BagItem = GameObject.Find("BagItem");
            PropItem = GameObject.Find("PropItem");
            BoxObj = GameObject.Find("Box");
            GenerateItem();
        }

        private void OnItemSelectFunction(OnItemSelectEvent e)
        {
            if (_itemDataMap.ContainsKey(e.LocalId))
            {
                _curSelectItemData = _itemDataMap[e.LocalId];
            }
            
        }

        public ViewItem GetItemUI(int localId)
        {
            if (_itemUIMap.TryGetValue(localId,out var item))
            {
                return item;
            }

            return null;
        }

        public UIDataItem GetItemData(int localId)
        {
            if (_itemDataMap.TryGetValue(localId,out var item))
            {
                return item;
            }

            return null;
        }
        
        
        // public UIDataItem GetCurSelectItemData()
        // {
        //     return _curSelectItemData;
        // }
        //
        // public ViewItem GetCurSelectItemUI()
        // {
        //     if (_itemUIMap.ContainsKey(_curSelectItemData.LocalId))
        //     {
        //         return _itemUIMap[_curSelectItemData.LocalId];
        //     }
        //     
        //     return null;
        // }
        
        
        public override void Update()
        {
            base.Update();
        }


        public void GenerateItem()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    var configId = i;
                    var config = ConfigManager.Instance.GetConfigItem(i);

                    var width = config.UIWidth;
                    var height = config.UIHeight;

                    GameObject obj = null;
                    if (configId == 4)
                    {
                        obj = Resources.Load($"ItemPrefab/Pack_{width}x{height}") as GameObject;
                    }
                    else
                    {
                        obj = Resources.Load($"ItemPrefab/{width}x{height}") as GameObject;   
                    }
              
                    _prefabs.Add(obj);
                
                    ViewItem item = null;
             
                    var go = GameObject.Instantiate(obj, BoxObj.transform);
                    go.transform.localPosition = Vector3.zero;
                    item = go.GetComponent<ViewItem>();
               
                    if (item == null)
                    {
                        item = go.AddComponent<ViewItem>();
                    }
                
                    var size = item.GetComponent<RectTransform>().rect;
                    var texture = Resources.Load<Texture>($"Texture/{config.TexturePath}") as Texture2D;
                    var img = go.GetComponent<Image>();
                    img.sprite = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),Vector2.zero);

                    img.rectTransform.sizeDelta = new Vector2(texture.width / 2, texture.height / 2);
                    
                    _itemMap.Add(_localId,config);

                  
                    _itemDataMap.Add(_localId,new UIDataItem(){ LocalId =  _localId, ConfigId =  i});
                    _itemUIMap.Add(_localId,item);
                    
                    item.LocalId = _localId;
                    _localId++;
                    item.ConfigId = i;
                }
            }
            
           
        }

        
        
        
        public ConfigItem GetItem(int localId)
        {
            if (_itemMap.ContainsKey(localId))
            {
                return _itemMap[localId];
            }

            return null;
        }

        public void OnItemSetToBag(ViewItem item)
        {
            item.SetRigState(false);
            
            if (_itemMap[item.LocalId].PropType == PropType.Bag)
            {
                item.transform.SetParent(BagItem.transform);
            }
            else
            {
                item.transform.SetParent(PropItem.transform);
            }
           
        }
        
        
        public void BackToBox(int localId)
        {
            if (!_itemUIMap.ContainsKey(localId))
            {
                return;
            }
            
            var item = _itemUIMap[localId];
            
            item.transform.SetParent(BoxObj.transform);
            item.transform.localPosition = Vector3.zero;
            item.SetRigState(true);
        }
        
    }
}