using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDataItem : UIDataBase
{
   public int LocalId;

   //哪些item吃到该物体的星 buff
   public HashSet<int> StarTargetLocalId = new HashSet<int>();
   
   
}
