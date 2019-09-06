// GENERATED AUTOMATICALLY FROM 'Assets/Controls/RLDControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class RLDControls : IInputActionCollection
{
    private InputActionAsset asset;
    public RLDControls()
    {
        asset = InputActionAsset.FromJson(@"{
            ""name"": ""RLDControls"",
            ""maps"": [
                {
                    ""name"": ""Menu"",
                    ""id"": ""563f8ed3-0989-482b-9612-0ec7fc0d4c70"",
                    ""actions"": [
                        {
                            ""name"": ""Toggle"",
                            ""type"": ""Button"",
                            ""id"": ""474ae6db-b1bf-4b4b-900f-6c23c9a4300d"",
                            ""expectedControlType"": """",
                            ""processors"": """",
                            ""interactions"": ""Press""
                        }
                    ],
                    ""bindings"": [
                        {
                            ""name"": """",
                            ""id"": ""7cad02e5-46ae-4b79-839f-bb4021068695"",
                            ""path"": ""<Keyboard>/escape"",
                            ""interactions"": """",
                            ""processors"": """",
                            ""groups"": ""Keyboard and Mouse"",
                            ""action"": ""Toggle"",
                            ""isComposite"": false,
                            ""isPartOfComposite"": false
                        }
                    ]
                }
            ],
            ""controlSchemes"": [
                {
                    ""name"": ""Keyboard and Mouse"",
                    ""bindingGroup"": ""Keyboard and Mouse"",
                    ""devices"": [
                        {
                            ""devicePath"": ""<Keyboard>"",
                            ""isOptional"": false,
                            ""isOR"": false
                        },
                        {
                            ""devicePath"": ""<Mouse>"",
                            ""isOptional"": false,
                            ""isOR"": false
                        }
                    ]
                }
            ]
        }");
        // Menu
        m_Menu = asset.GetActionMap("Menu");
        m_Menu_Toggle = m_Menu.GetAction("Toggle");
    }

    ~RLDControls()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Toggle;
    public struct MenuActions
    {
        private RLDControls m_Wrapper;
        public MenuActions(RLDControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle => m_Wrapper.m_Menu_Toggle;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                Toggle.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggle;
                Toggle.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggle;
                Toggle.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggle;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                Toggle.started += instance.OnToggle;
                Toggle.performed += instance.OnToggle;
                Toggle.canceled += instance.OnToggle;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }

    UnityEngine.InputSystem.InputBinding? IInputActionCollection.bindingMask { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public interface IMenuActions
    {
        void OnToggle(InputAction.CallbackContext context);
    }
}
