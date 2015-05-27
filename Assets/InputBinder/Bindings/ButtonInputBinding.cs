using UnityEngine;
using UnityEngine.Events;

namespace RyanNielson.InputBinder
{
    [System.Serializable]
    public class ButtonInputBinding : InputBinding
    {
        [SerializeField]
        private string name;

        [SerializeField]
        protected InputEvent inputEvent;

        [SerializeField]
        protected ActionEvent boundEvent = new ActionEvent();

        public ButtonInputBinding(string name, InputEvent inputEvent, UnityAction action)
        {
            this.name = name;
            this.inputEvent = inputEvent;
            this.boundEvent.AddListener(action);

            UpdateInspectorName();
        }

        protected bool ActionOccurred()
        {
            return (inputEvent == InputEvent.Pressed && Input.GetButtonDown(name)) || (inputEvent == InputEvent.Released && Input.GetButtonUp(name)) || (inputEvent == InputEvent.Held && Input.GetButton(name));
        }

        public override void Execute()
        {
            if (ActionOccurred())
            {
                boundEvent.Invoke();
            }
        }

        public void AddListener(UnityAction action)
        {
            boundEvent.AddListener(action);
        }

        public bool IsEquivalent(string name, InputEvent inputEvent)
        {
            return this.name == name && this.inputEvent == inputEvent;
        }

        public override void UpdateInspectorName()
        {
            inspectorName = name + " - " + inputEvent.ToString();
        }
    }
}