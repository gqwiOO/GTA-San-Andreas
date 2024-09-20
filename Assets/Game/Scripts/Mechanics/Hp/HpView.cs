using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Mechanics.Hp
{
    public class HpView: MonoBehaviour
    {
        [SerializeField] private Image bar;
        private IHp _hp;

        public void Init(IHp hp)
        {
            _hp = hp;
            _hp.OnPercentHpChanged += UpdateBar;
        }

        private void UpdateBar(float fillValue) => bar.fillAmount = fillValue;
    }
}