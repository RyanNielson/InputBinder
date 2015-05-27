using UnityEngine;
using UnityEngine.Events;

namespace RyanNielson.InputBinder
{
    [System.Serializable]
    public class KeyInputBinding : InputBinding
    {
        [SerializeField]
        private KeyCode key;

        [SerializeField]
        protected InputEvent inputEvent;

        [SerializeField]
        protected ActionEvent boundEvent = new ActionEvent();

        public KeyInputBinding(KeyCode key, InputEvent inputEvent, UnityAction action)
        {
            this.key = key;
            this.inputEvent = inputEvent;
            this.boundEvent.AddListener(action);

            UpdateInspectorName();
        }

        protected bool ActionOccurred()
        {
            return (inputEvent == InputEvent.Pressed && Input.GetKeyDown(key)) || (inputEvent == InputEvent.Released && Input.GetKeyUp(key)) || (inputEvent == InputEvent.Held && Input.GetKey(key));
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

        public bool IsEquivalent(KeyCode key, InputEvent inputEvent)
        {
            return this.key == key && this.inputEvent == inputEvent;
        }

        public override void UpdateInspectorName()
        {
            inspectorName = key.ToString() + " - " + inputEvent.ToString();
        }
    }
}
