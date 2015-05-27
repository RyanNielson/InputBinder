using UnityEngine;
using UnityEngine.Events;

namespace RyanNielson.InputBinder
{
    [System.Serializable]
    public class AxisInputBinding : InputBinding
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private AxisEvent boundEvent = new AxisEvent();

        private float value { get; set; }

        public AxisInputBinding(string name, UnityAction<float> action)
        {
            this.name = name;
            this.boundEvent.AddListener(action);
            this.value = 0f;

            UpdateInspectorName();
        }

        public void UpdateValue()
        {
            value = Input.GetAxis(name);
        }

        public override void Execute()
        {
            boundEvent.Invoke(value);
        }

        public void AddListener(UnityAction<float> action)
        {
            boundEvent.AddListener(action);
        }

        public bool IsEquivalent(string name)
        {
            return this.name == name;
        }

        public override void UpdateInspectorName()
        {
            inspectorName = name;
        }
    }
}
