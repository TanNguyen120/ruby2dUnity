// GENERATED AUTOMATICALLY FROM 'Assets/Script/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Ruby"",
            ""id"": ""636576e3-d1e3-4dc5-ae18-d80f228c8e18"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""e17f1b04-a9b8-403e-bf5c-6a8a4f3b5726"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""95dbc45d-70a7-4fe6-a8ce-6a5e11bd1388"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a45906c4-3bb3-4552-a5fe-d6c90e2cb098"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""361b87bb-f28e-4fc5-97e3-c2f920b4e7ce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c4ba2de8-6a69-45dd-9c03-15c2ef55f507"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e81a8471-76ce-47e5-99c8-ccf33ade8a97"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bac2d744-647a-4a0e-ac5a-8d3a3b64ba7c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2f662f63-1ba1-42ed-b37c-4047a70b5644"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4afb961d-caab-4777-a271-0bf4fb814f36"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ruby
        m_Ruby = asset.FindActionMap("Ruby", throwIfNotFound: true);
        m_Ruby_move = m_Ruby.FindAction("move", throwIfNotFound: true);
        m_Ruby_shoot = m_Ruby.FindAction("shoot", throwIfNotFound: true);
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

    // Ruby
    private readonly InputActionMap m_Ruby;
    private IRubyActions m_RubyActionsCallbackInterface;
    private readonly InputAction m_Ruby_move;
    private readonly InputAction m_Ruby_shoot;
    public struct RubyActions
    {
        private @Player m_Wrapper;
        public RubyActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Ruby_move;
        public InputAction @shoot => m_Wrapper.m_Ruby_shoot;
        public InputActionMap Get() { return m_Wrapper.m_Ruby; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RubyActions set) { return set.Get(); }
        public void SetCallbacks(IRubyActions instance)
        {
            if (m_Wrapper.m_RubyActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_RubyActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_RubyActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_RubyActionsCallbackInterface.OnMove;
                @shoot.started -= m_Wrapper.m_RubyActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_RubyActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_RubyActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_RubyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
            }
        }
    }
    public RubyActions @Ruby => new RubyActions(this);
    public interface IRubyActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
