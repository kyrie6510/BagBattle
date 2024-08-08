using System.Collections.Generic;

namespace Game
{
    public partial class ConfigManager
    {
        private Dictionary<short, TableTimingRowData> _timMap;


        private void LoadTableTimConfig()
        {
            if (_timMap == null)
            {
                _timMap = Load<TableTimingRowData>();
            }
        }

        public bool IsHaveTimingConfig(short id)
        {
            LoadTableTimConfig();
            if (id == 0) return false;
            return _timMap.ContainsKey(id);
        }
        
        public TableTimingRowData GetTimConfig(int id)
        {

            
            LoadTableTimConfig();
            return _timMap[(short) id];
        }

    }
}