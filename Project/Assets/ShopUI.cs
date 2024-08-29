using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private List<Text> _txtPriceList;
    
    [SerializeField]
    private List<GameObject> _objShopItemHolder;

    [SerializeField] private Button _btnRefresh;


    private void Awake()
    {
        EventManager.Instance.AddListener<OnGamePlayEvent>(OnGamePlay);
    }

    private void OnGamePlay(OnGamePlayEvent e)
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _btnRefresh.onClick.AddListener((() =>
        {

            var itemLocalId = ItemManager.Instance.GenerateItemForShop();

            for (int i = 0; i < _objShopItemHolder.Count; i++)
            {
                var holder = _objShopItemHolder[i];
                var localId = itemLocalId[i];

                var viewItem = ItemManager.Instance.GetItemUI(localId);
                
                viewItem.SetRigState(false);
                viewItem.transform.SetParent(holder.transform);
                viewItem.transform.localPosition = Vector3.zero;
            }
            

        }));
    }

  
    
    
    
    
}
