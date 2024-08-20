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
    
    public void RemoveInfo(int localId)
    {
        if (localId == LocalIdItem)  LocalIdItem = 0;
        if (localId == LocalIdBag) LocalIdBag = 0;
    }

    public void PutItemData(int itemId,int itemConfigId)
    {
        var config = ConfigManager.Instance.GetPropConfig((short)itemConfigId);
        if (config.PropType == (int)PropType.Bag)
        {
            LocalIdBag = itemId;
        }
        else
        {
            LocalIdItem = itemId;
        }
    }
    
}
