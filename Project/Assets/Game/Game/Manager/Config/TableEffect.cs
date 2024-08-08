using System.Collections.Generic;

namespace Game
{
    public partial class ConfigManager
    {
        private Dictionary<short, TableEffectRowData> _effectMap;
        
        
        private void LoadTableEffectConfig()
        {
            if (_effectMap == null)
            {
                _effectMap = Load<TableEffectRowData>();
            }
        }
        
          
        public TableEffectRowData GetEffectConfig(int id)
        {
            LoadTableEffectConfig();
            
            return _effectMap[(short)id];
        }
        
    }
}