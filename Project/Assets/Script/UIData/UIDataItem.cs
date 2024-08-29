using System.Collections.Generic;
using UnityEngine;


public class UIDataItem : UIDataBase
{
   public int LocalId;

   public int ConfigId;
   
   public bool IsRoatete = false;
   public int RotateValue = 0;
   
   //哪些item吃到该物体的星 buff
   public HashSet<int> StarTargetLocalId = new HashSet<int>();

   /// <summary>
   /// 0:商店 1:背包 2:箱子
   /// </summary>
   public int State;

   public Vector2 LocalPos;


   public bool IsBag;
   
   public HashSet<int> BagItemId = new HashSet<int>();
}
