using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

namespace RyanNielson.InputBinder
{
    public class InputBinder : MonoBehaviour
    {
        [SerializeField]
        private List<AxisInputBinding> axisBindings = new List<AxisInputBinding>();

        [SerializeField]
        private List<ButtonInputBinding> buttonBindings = new List<ButtonInputBinding>();

        [SerializeField]
        private List<KeyInputBinding> keyBindings = new List<KeyInputBinding>();

        public void BindAxis(string name, UnityAction<float> action)
        {
            AxisInputBinding axisBinding = axisBindings.FirstOrDefault(binding => binding.IsEquivalent(name));

            if (axisBinding == null)
            {
                axisBindings.Add(new AxisInputBinding(name, action));
            }
            else
            {
                axisBinding.AddListener(action);
            }
        }

        public void BindButton(string name, InputEvent inputEvent, UnityAction action)
        {
            ButtonInputBinding buttonBinding = buttonBindings.FirstOrDefault(binding => binding.IsEquivalent(name, inputEvent));

            if (buttonBinding == null)
            {
                buttonBindings.Add(new ButtonInputBinding(name, inputEvent, action));
            }
            else
            {
                buttonBinding.AddListener(action);
            }
        }

        public void BindKey(KeyCode key, InputEvent inputEvent, UnityAction action)
        {
            KeyInputBinding keyBinding = keyBindings.FirstOrDefault(binding => binding.IsEquivalent(key, inputEvent));

            if (keyBinding == null)
            {
                keyBindings.Add(new KeyInputBinding(key, inputEvent, action));
            }
            else
            {
                keyBinding.AddListener(action);
            }
        }

        public void Update()
        {
            UpdateAxisBindings();

            ExecuteAxisBindings();

            ExecuteButtonBindings();

            ExecuteKeyBindings();
        }

        private void UpdateAxisBindings()
        {
            foreach (AxisInputBinding axisBinding in axisBindings)
            {
                axisBinding.UpdateValue();
            }
        }

        private void ExecuteAxisBindings()
        {
            foreach (AxisInputBinding axisBinding in axisBindings)
            {
                axisBinding.Execute();
            }
        }

        private void ExecuteButtonBindings()
        {
            foreach (ButtonInputBinding buttonBinding in buttonBindings)
            {
                buttonBinding.Execute();
            }
        }

        private void ExecuteKeyBindings()
        {
            foreach (KeyInputBinding keyBinding in keyBindings)
            {
                keyBinding.Execute();
            }
        }

        private void OnValidate()
        {
            foreach (AxisInputBinding axisBinding in axisBindings)
            {
                axisBinding.UpdateInspectorName();
            }

            foreach (ButtonInputBinding buttonBinding in buttonBindings)
            {
                buttonBinding.UpdateInspectorName();
            }

            foreach (KeyInputBinding keyBinding in keyBindings)
            {
                keyBinding.UpdateInspectorName();
            }
        }
    }
}
