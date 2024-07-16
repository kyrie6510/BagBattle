using System;
using System.Reflection;
using UnityEditor;

namespace Script
{
    public static class Utility
    {
        static MethodInfo clearMethod = null;
        
        /// <summary>
        /// 清空log信息
        /// </summary>
        public static void ClearConsole()
        {
            if (clearMethod == null)
            {
                Type log = typeof(EditorWindow).Assembly.GetType("UnityEditor.LogEntries");
                clearMethod = log.GetMethod("Clear");
            }
        
            clearMethod.Invoke(null, null);
        }
    }
}