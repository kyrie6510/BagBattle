using System.Collections.Generic;


public class UIDataItem : UIDataBase
{
   public int LocalId;

   public short ConfigId;
   
   public bool IsRoatete = false;
   public int RotateValue = 0;
   
   //哪些item吃到该物体的星 buff
   public HashSet<int> StarTargetLocalId = new HashSet<int>();

   public bool IsInBag;
}
