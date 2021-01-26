// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputSystem/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Terrain"",
            ""id"": ""296ae6c3-01a1-4f4f-9ec5-a2f3833c182b"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9a75ddae-d4e5-405c-88be-e6f5e3898662"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""072ecb00-3836-441e-b163-a496d12dfbda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19d317a6-4e4c-4b96-b568-cda03bc4edf3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c20efb8-3704-41c3-a553-efafd5672e12"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0da8b4ad-46f2-4402-954a-e9b54e5a242f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""d6862be0-ab4d-4ad1-88fa-50fc1f643730"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5eb2adc6-0f2f-417a-a694-0b453cae6bc2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c32b3be8-7daf-49ab-8a66-3d03bf8dedb3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Terrain
        m_Terrain = asset.FindActionMap("Terrain", throwIfNotFound: true);
        m_Terrain_Interact = m_Terrain.FindAction("Interact", throwIfNotFound: true);
        m_Terrain_Move = m_Terrain.FindAction("Move", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Position = m_Mouse.FindAction("Position", throwIfNotFound: true);
    }

    public void Dispose()
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

    // Terrain
    private readonly InputActionMap m_Terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_Terrain_Interact;
    private readonly InputAction m_Terrain_Move;
    public struct TerrainActions
    {
        private @PlayerControl m_Wrapper;
        public TerrainActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Terrain_Interact;
        public InputAction @Move => m_Wrapper.m_Terrain_Move;
        public InputActionMap Get() { return m_Wrapper.m_Terrain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TerrainActions set) { return set.Get(); }
        public void SetCallbacks(ITerrainActions instance)
        {
            if (m_Wrapper.m_TerrainActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnInteract;
                @Move.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_TerrainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public TerrainActions @Terrain => new TerrainActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Position;
    public struct MouseActions
    {
        private @PlayerControl m_Wrapper;
        public MouseActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Mouse_Position;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface ITerrainActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnPosition(InputAction.CallbackContext context);
    }
}
