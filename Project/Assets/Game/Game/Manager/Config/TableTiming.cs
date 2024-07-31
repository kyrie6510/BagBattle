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
        
        public TableTimingRowData GetTimConfig(short id)
        {
            LoadTableTimConfig();
            return _timMap[id];
        }

    }
}