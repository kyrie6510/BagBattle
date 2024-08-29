using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


namespace Script
{
    public class ItemManager : Singleton<ItemManager>
    {
        public List<GameObject> _prefabs;

        public GameObject ObjMyBagItems;
        public GameObject ObjMyProps;

        public GameObject ObjBox;

        public GameObject ObjOtherBagItems;
        public GameObject ObjOtherProps;

        public GameObject ObjOtherBag;

      //  private Dictionary<int, ConfigItem> _itemMap = new Dictionary<int, ConfigItem>();
        private Dictionary<int, UIDataItem> _itemDataMap = new Dictionary<int, UIDataItem>();
        private Dictionary<int, ViewItem> _itemUIMap = new Dictionary<int, ViewItem>();
        private int _localId = 1;

        private UIDataItem _curSelectItemData;

        public override void Awake()
        {
            base.Awake();

            EventManager.Instance.AddListener<OnItemSelectEvent>(OnItemSelectFunction);
          
            _prefabs = new List<GameObject>();

            ObjMyBagItems = GameObject.Find("BagItem");
            ObjMyProps = GameObject.Find("PropItem");

            ObjBox = GameObject.Find("Box");

            ObjOtherBagItems = GameObject.Find("OtherBagItem");
            ObjOtherProps = GameObject.Find("OtherPropItem");
            ObjOtherBag = GameObject.Find("OtherPropItem");
            
            ObjOtherBag.transform.parent.gameObject.SetActive(false);
            
            _shopItemsLocalId = new() {-1, -1, -1, -1, -1};
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
            if (_itemUIMap.TryGetValue(localId, out var item))
            {
                return item;
            }

            return null;
        }

        public UIDataItem GetItemData(int localId)
        {
            if (_itemDataMap.TryGetValue(localId, out var item))
            {
                return item;
            }

            return null;
        }


        private List<int> _shopItemsLocalId = new ();
        
        public List<int> GenerateItemForShop()
        {
            var count = _shopItemsLocalId.Count;

            if (count == 5)
            {
                for (int i = 0; i < _shopItemsLocalId.Count; i++)
                {
                    var localId = _shopItemsLocalId[i];
                    
                    if(localId == -1) continue;

                    var data = GetItemData(localId);
                    if (data.State != 0)
                    {
                        _shopItemsLocalId[i] = -1;
                    }
                }
            }
            
          
            
            for (short i = 1; i <= 5; i++)
            {
                var shopItemLocalId = _shopItemsLocalId[i - 1];

                Random random = new();
                var randomConfigId = random.Next(1, 10);
                    
                var cfgData  =  ConfigManager.Instance.GetPropConfig(randomConfigId);
                
                // == -1 已经不在商店
                if (shopItemLocalId != -1)
                {
                    var data = GetItemData(shopItemLocalId);
                    if (data.ConfigId == randomConfigId)
                    {
                        continue;
                    }

                    data.ConfigId = randomConfigId;
                    
                    bool isBag = cfgData.PropType == (int) PropType.Bag;
                    if (isBag) data.IsBag = true;

                    var viewItem = GetItemUI(data.LocalId);
                    viewItem.SetInfo(randomConfigId,data.LocalId);
                    
                    SetSpriteFromConfigId(viewItem.gameObject,randomConfigId);
                }
                else
                {
                    var data = CreatUIData(randomConfigId);
                    
                    bool isBag = cfgData.PropType == (int) PropType.Bag;
                    if (isBag) data.IsBag = true;
                    
                    
                    var go = CreatGameObject(randomConfigId, ObjBox.transform);
                    var item = go.GetComponent<ViewItem>();

                    item.SetInfo(randomConfigId,data.LocalId);
                    
                   
                    _shopItemsLocalId[i - 1] = item.LocalId;
                    
                    _itemUIMap.Add(data.LocalId, item);

                }
              
                
              
                
              
            }

            return _shopItemsLocalId;
        }
        
        public void GenerateItem()
        {
            for (short i = 1; i <= 10; i++)
            {
                var configId = i;
                
                var cfgData  =  ConfigManager.Instance.GetPropConfig(configId);

                bool isBag = cfgData.PropType == (int) PropType.Bag;
                var times =  isBag? 3 : 1;
                
                for (int j = 0; j < times; j++)
                {
                    var data = CreatUIData(configId);
                    if (isBag) data.IsBag = true;
                    
                    
                    var go = CreatGameObject(configId, ObjBox.transform);
                    var item = go.GetComponent<ViewItem>();

                    item.SetInfo(configId,data.LocalId);
                    
                    _itemUIMap.Add(data.LocalId, item);
                }
            }
        }

        public void Reset()
        {
            var objs = _itemUIMap.Values.ToList();
            for (int i = objs.Count - 1; i >= 0; i--)
            {
                var obj = objs[i];
                obj.DoDestroy();
            }
            _itemUIMap.Clear();
            _itemDataMap.Clear();
        }
        
        

        private UIDataItem CreatUIData(int configId)
        {
            var data = new UIDataItem() {LocalId = _localId, ConfigId = configId};
            _itemDataMap.Add(_localId, data);
            _localId++;
            return data;
            
            
        }


        private GameObject CreatGameObject(int configId, Transform parent)
        {
            var config = ConfigManager.Instance.GetPropConfig((short) configId);

            var width = config.UIWidth;
            var height = config.UIHeight;

            GameObject obj = null;
            
            obj = Resources.Load($"ItemPrefab/ViewItem") as GameObject;

            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(width*80,height*80 );
            
            _prefabs.Add(obj);

            ViewItem item = null;

            var go = GameObject.Instantiate(obj, parent);
            go.transform.localPosition = Vector3.zero;
          
            SetSpriteFromConfigId(go,configId);
            
            return go;
        }

        private void SetSpriteFromConfigId(GameObject go,int configId)
        {
            var item = go.GetComponent<ViewItem>();
            var config = ConfigManager.Instance.GetPropConfig(configId);
            
            
            if (item == null)
            {
                item = go.AddComponent<ViewItem>();
            }

            var size = item.GetComponent<RectTransform>().rect;
            var texture = Resources.Load<Texture>($"Texture/{config.TexturePath}") as Texture2D;
            var img = go.GetComponent<Image>();
            img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            img.rectTransform.sizeDelta = new Vector2(texture.width / 2, texture.height / 2);

        }
        

        public void GenerateItemForOther(List<UIDataItem> dates)
        {

            //TODO 暂时放这里
            if (!ObjOtherBag.transform.parent.gameObject.activeInHierarchy)
            {
                ObjOtherBag.transform.parent.gameObject.SetActive(true);
            }
            
            foreach (var data in dates)
            {
                if(data.State!= 1) continue;

                var go = CreatGameObject(data.ConfigId, ObjOtherBag.transform);

                var view = go.GetComponent<ViewItem>();
                view.SetRigState(false);
                
                view.ConfigId = data.ConfigId;
                view.LocalId = data.LocalId;
                
                OnItemSetToBag(view, false);

                go.transform.localPosition = data.LocalPos;
                go.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, -data.RotateValue);
                
                _itemUIMap.Add(data.LocalId, view);
            }
        }


        public int GetItemPropType(int localId)
        {
            if (!_itemDataMap.ContainsKey(localId))
            {
                return -1;
            }

            return ConfigManager.Instance.GetPropConfig(_itemDataMap[localId].ConfigId).PropType;
        }
        
        public int GetItemPropConfigId(int localId)
        {
            if (!_itemDataMap.ContainsKey(localId))
            {
                return -1;
            }

            return _itemDataMap[localId].ConfigId;
        }

        public void OnItemSetToBag(ViewItem item, bool isMyBag = true)
        {
            item.SetRigState(false);

            var data = GetItemData(item.LocalId);
            data.State = 1;

            if (GetItemPropType(item.LocalId) == (int) PropType.Bag)
            {
                var parent = isMyBag ? ObjMyBagItems : ObjOtherBagItems;

                item.transform.SetParent(parent.transform);
            }
            else
            {
                var parent = isMyBag ? ObjMyProps : ObjOtherProps;
                item.transform.SetParent(parent.transform);
            }
        }


        public void BackToBox(int localId)
        {
            if (!_itemUIMap.ContainsKey(localId))
            {
                return;
            }

            var data = GetItemData(localId);
            data.State = 2;


            var item = _itemUIMap[localId];

            item.transform.SetParent(ObjBox.transform);
            item.transform.localPosition = Vector3.zero;
            item.SetRigState(true);
        }

        public List<UIDataItem> GetAllItemData()
        {
            return _itemDataMap.Values.ToList();
        }

        public List<UIDataItem> GetOtherData()
        {
            List<UIDataItem> list = new List<UIDataItem>();

            var inBagList = _itemDataMap.Values.ToList();
            var offset = inBagList.Count;
            foreach (var item in inBagList)
            {
              
                var creatData = CreatUIData(item.ConfigId);

                creatData.IsRoatete = item.IsRoatete;
                creatData.LocalPos = item.LocalPos;
                
                creatData.StarTargetLocalId = new();
                creatData.BagItemId = new();
                
                
                
                foreach (var local in item.StarTargetLocalId)
                {
                    creatData.StarTargetLocalId.Add(local + offset);
                }
                
                foreach (var local in item.BagItemId)
                {
                    creatData.BagItemId.Add(local + offset);
                }

                
                
                creatData.RotateValue = item.RotateValue;
                creatData.State = item.State;


                list.Add(creatData);
            }

            return list;
        }

        public void SetLeftData()
        {
        }
    }
}