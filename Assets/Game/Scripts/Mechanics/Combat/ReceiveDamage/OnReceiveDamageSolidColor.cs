using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Mechanics.Combat.ReceiveDamage
{
    public class OnReceiveDamageSolidColor: MonoBehaviour
    {
        [SerializeField] private AttackObject attackObject;
        
        [SerializeField] private List<SpriteRenderer> spriteRenderers;
        [SerializeField] private Material solidColorMaterial;
        [SerializeField] private Material defaultMaterial;

        [SerializeField] private int durationMilliseconds;
#if UNITY_EDITOR
        [Button]
        private void AutoDependencies()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>().ToList();
        }
#endif

        private void Start()
        {
            attackObject.OnReceiveDamage += ChangeColor_OnReceiveDamage;
        }

        private void ChangeColor_OnReceiveDamage(float _) => ChangeColor().Forget();
        private void OnDestroy() => attackObject.OnReceiveDamage -= ChangeColor_OnReceiveDamage;

        private async UniTask ChangeColor()
        {
            if (attackObject.IsDead)
                return;
            spriteRenderers.ForEach(r => r.material = solidColorMaterial);
            await UniTask.Delay(durationMilliseconds);
            spriteRenderers.ForEach(r => r.material = defaultMaterial);
        }
    }
}