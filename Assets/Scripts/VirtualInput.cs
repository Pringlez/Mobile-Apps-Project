using System.Collections.Generic;
using UnityEngine;

namespace UserControl.CrossPlatformInput
{
    public abstract class VirtualInput
    {
        protected Dictionary<string, InputManager.VirtualAxis> virtualAxes =
			new Dictionary<string, InputManager.VirtualAxis>();

		protected Dictionary<string, InputManager.VirtualButton> virtualButtons =
			new Dictionary<string, InputManager.VirtualButton>();

        protected List<string> alwaysUseVirtual = new List<string>();
        public Vector3 virtualMousePosition { get; private set; }

		public void RegisterVirtualAxis(InputManager.VirtualAxis axis)
        {
            if (virtualAxes.ContainsKey(axis.name))
            {
                Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
            }
            else
            {
                virtualAxes.Add(axis.name, axis);

                if (!axis.matchWithInputManager)
                {
                    alwaysUseVirtual.Add(axis.name);
                }
            }
        }
		
		public void RegisterVirtualButton(InputManager.VirtualButton button)
        {
            if (virtualButtons.ContainsKey(button.name))
            {
                Debug.LogError("There is already a virtual button named " + button.name + " registered.");
            }
            else
            {
                virtualButtons.Add(button.name, button);

                if (!button.matchWithInputManager)
                {
                    alwaysUseVirtual.Add(button.name);
                }
            }
        }
		
        public void UnRegisterVirtualAxis(string name)
        {
            if (virtualAxes.ContainsKey(name))
            {
                virtualAxes.Remove(name);
            }
        }
		
        public void UnRegisterVirtualButton(string name)
        {
            if (virtualButtons.ContainsKey(name))
            {
                virtualButtons.Remove(name);
            }
        }
		
		public InputManager.VirtualAxis VirtualAxisReference(string name)
        {
            return virtualAxes.ContainsKey(name) ? virtualAxes[name] : null;
        }
		
        public void SetVirtualMousePositionX(float f)
        {
            virtualMousePosition = new Vector3(f, virtualMousePosition.y, virtualMousePosition.z);
        }
		
        public void SetVirtualMousePositionY(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, f, virtualMousePosition.z);
        }
		
        public void SetVirtualMousePositionZ(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, virtualMousePosition.y, f);
        }
		
        public abstract float GetAxis(string name, bool raw);

        public abstract bool GetButton(string name);
        public abstract bool GetButtonDown(string name);
        public abstract bool GetButtonUp(string name);

        public abstract void SetButtonDown(string name);
        public abstract void SetButtonUp(string name);
        public abstract void SetAxisPositive(string name);
        public abstract void SetAxisNegative(string name);
        public abstract void SetAxisZero(string name);
        public abstract void SetAxis(string name, float value);
        public abstract Vector3 MousePosition();
    }
}