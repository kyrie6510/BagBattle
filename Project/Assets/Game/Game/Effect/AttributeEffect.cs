using System;

namespace Game
{
    public class AttributeEffect : Attribute
    {
        public EffectType Type;
        public int EffectClass;
        public string Info;
        public AttributeEffect(EffectType type, int effectClass,string info)
        {
            this.EffectClass = effectClass;
            this.Type = type;
            this.Info = info;
        }
        
        
        
    }
}