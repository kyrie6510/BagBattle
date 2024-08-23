using Game;
using Script;


public class UIDataBase
{
    
}


public class UIDataGrid 
{
    //位置
    public int X;
    public int Y;

    public int Id;
    
    public int LocalIdItem;
    public int LocalIdBag;
    //哪个物品的Star
    public int LocalIdStar;


    public void Reset()
    {
        this.LocalIdItem = 0;
        this.LocalIdBag = 0;
        this.LocalIdStar = 0;
    }
    
    public void RemoveData(int localId)
    {
        if (localId == LocalIdItem)
        {
            LocalIdItem = 0;
            var bagData = ItemManager.Instance.GetItemData(LocalIdBag);
            bagData.BagItemId.Add(LocalIdBag);
            bagData.BagItemId.Remove(localId);

        }
        if (localId == LocalIdBag) LocalIdBag = 0;
    }

    public void PutData(int itemId,int itemConfigId)
    {
        var config = ConfigManager.Instance.GetPropConfig((short)itemConfigId);
        if (config.PropType == (int)PropType.Bag)
        {
            LocalIdBag = itemId;
        }
        else
        {
            var bagData = ItemManager.Instance.GetItemData(LocalIdBag);
            bagData.BagItemId.Add(itemId);
            
            LocalIdItem = itemId;
        }
        
        
        
    }
    
}
