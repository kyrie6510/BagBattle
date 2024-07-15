using UnityEngine;


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


    public void RemoveInfo(int localId)
    {
        if (localId == LocalIdItem)  LocalIdItem = 0;
        if (localId == LocalIdBag) LocalIdBag = 0;
    }
}
