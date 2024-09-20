using System;
using System.Xml;

namespace Game.Scripts.Mechanics.Hp
{
    public interface IHp
    {
        float Current { get; }
        float MaxValue { get; }
        
        void Damage(float value);
        
        void Heal(float value);
        
        event Action OnDied;
        event Action<float> OnPercentHpChanged;
    }
}
   
