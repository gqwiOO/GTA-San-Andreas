using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Mechanics.UI
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private Action _onClick;
        public event Action OnClick;

#if UNITY_EDITOR

        private void OnValidate() => AutoDependence();

        [Button]
        [HorizontalGroup]
        [PropertyOrder(-1)]
        private void AutoDependence()
        {
            if (!Application.isEditor)
                return;

            if (EditorApplication.isPlaying)
                return;

            if (TryGetComponent(out Button result))
            {
                button = result;
            }
            else
            {
                button = gameObject.AddComponent<Button>();
                UnityEditorInternal.ComponentUtility.MoveComponentUp(button);
            }

            Undo.RecordObject(button, nameof(AutoDependence));
        }
#endif
        private void Start()
        {
            button.onClick.AddListener(Click);
            StartHook();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            OnClick?.Invoke();
            ClickHook();
        }
        
        protected virtual void StartHook() { }

        protected virtual void ClickHook() { }
    }
}