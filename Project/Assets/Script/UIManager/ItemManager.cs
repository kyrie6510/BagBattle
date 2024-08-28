using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.UI;


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
        
        

        private UIDataItem CreatUIData(short configId)
        {
            var data = new UIDataItem() {LocalId = _localId, ConfigId = (short) configId};
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
            item = go.GetComponent<ViewItem>();

            if (item == null)
            {
                item = go.AddComponent<ViewItem>();
            }

            var size = item.GetComponent<RectTransform>().rect;
            var texture = Resources.Load<Texture>($"Texture/{config.TexturePath}") as Texture2D;
            var img = go.GetComponent<Image>();
            img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            img.rectTransform.sizeDelta = new Vector2(texture.width / 2, texture.height / 2);

            return go;
        }

        public void GenerateItemForOther(List<UIDataItem> dates)
        {
            foreach (var data in dates)
            {
                if(!data.IsInBag) continue;

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
            data.IsInBag = true;

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
            data.IsInBag = false;


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
                creatData.IsInBag = item.IsInBag;


                list.Add(creatData);
            }

            return list;
        }

        public void SetLeftData()
        {
        }
    }
}