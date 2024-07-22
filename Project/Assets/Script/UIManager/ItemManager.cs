using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;
using Image = UnityEngine.UI.Image;

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


        private void GenerateItem()
        {
            for (short i = 1; i <= 8; i++)
            {
                var configId = i;

                var data = CreatUIData(configId);

                var go = CreatGameObject(i, ObjBox.transform);
                var item = go.GetComponent<ViewItem>();

                item.ConfigId = configId;
                item.LocalId = data.LocalId;

                _itemUIMap.Add(data.LocalId, item);
            }
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
            List<UIDataItem> list = new List<UIDataItem>();
            foreach (var item in _itemDataMap.Values)
            {
                if (item.IsInBag)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public List<UIDataItem> GetOtherData()
        {
            List<UIDataItem> list = new List<UIDataItem>();

            var inBagList = _itemDataMap.Values.ToList();
            foreach (var item in inBagList)
            {
                if (item.IsInBag)
                {
                    var creatData = CreatUIData(item.ConfigId);

                    creatData.IsRoatete = item.IsRoatete;
                    creatData.LocalPos = item.LocalPos;
                    creatData.StarTargetLocalId = item.StarTargetLocalId;
                    creatData.RotateValue = item.RotateValue;
                    creatData.IsInBag = true;


                    list.Add(creatData);
                }
            }

            return list;
        }

        public void SetLeftData()
        {
        }
    }
}