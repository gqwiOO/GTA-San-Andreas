using System;

namespace Game.Scripts.Mechanics.Hp
{
    public class Hp : IHp
    {
        public float Current { get; private set; }
        
        public float MaxValue { get;  private set;}

        public event Action OnDied;
        
        public event Action<float> OnPercentHpChanged;

        public Hp(int MaxHp)
        {
            MaxValue = MaxHp;
            Current = MaxValue;
        }

        public void Damage(float value)
        {
            Current -= value;
            if (Current < 0)
            {
                Current = 0;
                OnDied?.Invoke();
            }
            OnPercentHpChanged?.Invoke(Current / MaxValue);
            
        }

        public void Heal(float value)
        {
            Current += value;
            if (Current > MaxValue)
                Current = MaxValue;
        }
    }
}