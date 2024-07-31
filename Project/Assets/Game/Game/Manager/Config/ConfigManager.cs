using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.Collections.Generic;
using FlatBuffers;
using Script;

namespace Game
{
    public partial class  ConfigManager : Singleton<ConfigManager>
    {
        public override void Awake()
        {
            base.Awake();
            
            
        }

        private Assembly ass;
        
        public Dictionary<short, T> Load<T>()
        {
            
            ass = Assembly.Load("config-flat");
            
            var type1 = typeof(T);
            var type2Name = type1.Name.Substring(0, type1.Name.Length - 7);
            
            TextAsset studentTextAsset = Resources.Load<TextAsset>($"Data/{type2Name}");
            byte[] bytes = studentTextAsset.bytes;
        
            
            // var bytes =    
            //     Loader.LoadFile($"Config/bytes/{type2Name}.bytes");
            Dictionary<short, T> Dict = new Dictionary<short, T>();
            var type2 = ass.GetType(type2Name);
            var m = type2.GetMethod("GetRootAs" + type2Name, new Type[] { typeof(ByteBuffer) });
            var s1 = m.Invoke(type2, new object[] { new ByteBuffer(bytes) });
            var listMethod = type2.GetMethod("Datalist");
            listMethod.Invoke(s1, new object[] { 0 });
            //var lengthField = type2.GetField("DatalistLength");
            var lengthField = type2.GetProperty("DatalistLength");
            int len = (int)lengthField.GetValue(s1);
            var idFiled = type1.GetProperty("Id");
            for (int i = 0; i < len; i++)
            {
                T item = (T)listMethod.Invoke(s1, new object[] { i });
                short id = (short)idFiled.GetValue(item);
                Dict.Add(id, item);
            }
            
            return Dict;
        }
        
        
        
        
    }
}